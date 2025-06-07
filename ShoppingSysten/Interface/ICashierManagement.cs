using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    internal interface ICashierManagement
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByOrderID(int orderID);
        Task<Order> GetOrderByIdCustomer(int customerId);
        Task AddOrderForCustomer(Order order, int customerId);
        Task<Order> DeleteOrder(int customerId, Order order);
        Task<Order> Update(int customerId, Order order);
    }
}
