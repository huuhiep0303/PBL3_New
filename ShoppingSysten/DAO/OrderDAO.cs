using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;
using Interface;

namespace ShoppingSysten.DAO
{
    public class OrderDAO : IOrderDAO
    {
        private readonly string connectionString;

        public OrderDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> InsertOrder(Order order)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("INSERT INTO Orders (CustomerId, OrderDate, Status) OUTPUT INSERTED.OrderId VALUES (@CustomerId, @Date, @Status)", conn);
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@Date", order.OrderDate);
            cmd.Parameters.AddWithValue("@Status", (int)order.status);
            return (int)await cmd.ExecuteScalarAsync();
        }

        public async Task InsertOrderItem(int orderId, OrderItem item)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("INSERT INTO OrderItems (OrderId, ProductId, ProductName, UnitPrice, Quantity) VALUES (@OrderId, @ProductId, @Name, @UnitPrice, @Quantity)", conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
            cmd.Parameters.AddWithValue("@Name", item.ProductName);
            cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var order = new Order();
            order.Items = new List<OrderItem>();

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            // Get Order
            var cmdOrder = new SqlCommand("SELECT * FROM Orders WHERE OrderId = @Id", conn);
            cmdOrder.Parameters.AddWithValue("@Id", orderId);
            using var reader = await cmdOrder.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                order.OrderId = reader.GetInt32(0);
                order.CustomerId = reader.GetInt32(1);
                order.OrderDate = reader.GetDateTime(2);
                order.status = (Status)reader.GetInt32(3);
            }
            else return null;

            reader.Close();

            // Get Order Items
            var cmdItems = new SqlCommand("SELECT * FROM OrderItems WHERE OrderId = @OrderId", conn);
            cmdItems.Parameters.AddWithValue("@OrderId", orderId);
            using var readerItems = await cmdItems.ExecuteReaderAsync();
            while (await readerItems.ReadAsync())
            {
                var item = new OrderItem(
                    readerItems.GetInt32(2),
                    readerItems.GetString(3),
                    readerItems.GetDecimal(4),
                    readerItems.GetInt32(5)
                );
                order.Items.Add(item);
            }

            return order;
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            var result = new List<Order>();

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM Orders WHERE CAST(OrderDate AS DATE) = @Date", conn);
            cmd.Parameters.AddWithValue("@Date", date.Date);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Order
                {
                    OrderId = reader.GetInt32(0),
                    CustomerId = reader.GetInt32(1),
                    OrderDate = reader.GetDateTime(2),
                    status = (Status)reader.GetInt32(3)
                });
            }
            return result;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var result = new List<Order>();

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM Orders", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Order
                {
                    OrderId = reader.GetInt32(0),
                    CustomerId = reader.GetInt32(1),
                    OrderDate = reader.GetDateTime(2),
                    status = (Status)reader.GetInt32(3)
                });
            }
            return result;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            // Xóa OrderItems trước
            var cmdItems = new SqlCommand("DELETE FROM OrderItems WHERE OrderId = @Id", conn);
            cmdItems.Parameters.AddWithValue("@Id", orderId);
            await cmdItems.ExecuteNonQueryAsync();

            // Xóa Order
            var cmdOrder = new SqlCommand("DELETE FROM Orders WHERE OrderId = @Id", conn);
            cmdOrder.Parameters.AddWithValue("@Id", orderId);
            int rows = await cmdOrder.ExecuteNonQueryAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateOrderStatus(int orderId, Status newStatus)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("UPDATE Orders SET Status = @Status WHERE OrderId = @Id", conn);
            cmd.Parameters.AddWithValue("@Status", (int)newStatus);
            cmd.Parameters.AddWithValue("@Id", orderId);
            int rows = await cmd.ExecuteNonQueryAsync();
            return rows > 0;
        }
    }

}
