using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    public interface IOrderDAO
    {
        Task<int> InsertOrder(Order order);
        Task InsertOrderItem(int orderId, OrderItem item);
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetOrdersByDate(DateTime date);
        Task<List<Order>> GetAllOrders();
        Task<bool> DeleteOrder(int orderId);
        Task<bool> UpdateOrderStatus(int orderId, Status newStatus);

    }

}
