using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;
using Interface;

namespace BLL
{
    public class CashierManagement : ICashierManagement
    {
        private readonly IOrderDAO _orderDAO;

        public CashierManagement(IOrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        // Lấy tất cả đơn hàng
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderDAO.GetAllOrders();
        }

        // Lấy đơn hàng theo mã đơn
        public async Task<Order> GetOrderByOrderID(int orderID)
        {
            return await _orderDAO.GetOrderById(orderID);
        }

        // Lấy đơn hàng theo mã khách hàng (giả sử 1 khách có 1 đơn gần nhất)
        public async Task<Order> GetOrderByIdCustomer(int customerId)
        {
            return await _orderDAO.GetOrderById(customerId);
        }

        // Thêm đơn hàng cho khách
        public async Task<Order> AddOrderForCustomer(Order order, int customerId)
        {
            order.CustomerId = customerId;
            order.OrderDate = DateTime.Now;
            order.status = Status.Pending; // hoặc giá trị mặc định khác

            var insertedOrder = await _orderDAO.InsertOrder(order);
            return insertedOrder;
        }

        // Cập nhật đơn hàng
        public async Task<Order> Update(int customerId, Order order)
        {
            order.CustomerId = customerId;
            var updated = await _orderDAO.UpdateOrderAsync(order);
            return updated;
        }

        // Xoá đơn hàng
        public async Task<Order> DeleteOrder(int customerId, Order order)
        {
            await _orderDAO.DeleteOrderAsync(order.OrderId);
            return order;
        }
    }

}
