using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace Interface
{
    public interface IOrderManagement
    {
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrderByDateTime(DateTime date);
        Task<Order> CreateOrder(int customerId, List<(int productID, int quantity)> items);
        Task DisplayAllOrder();
        Task DisplayOrderByDate(DateTime date);
        Task<bool> DeleteOrder(int orderID);
        Task<bool> CancelOrder(int orderID);
        Task CancelOverDueOrder(TimeSpan ts);
    }
}
