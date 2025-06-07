using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    interface IAdminManagement
    {
        Task<List<Customer>> GetInforCustomer(int customerId);
        Task <List<Employee>> GetInforEmployee(int employeeId);
        Task<List<Order>> GetInforOrder(int orderId);
        Task DeleteEmployee(int employeeId);
        Task DeleteOrder(int orderId);
        Task <List<Order>> GetOrdersByDate(DateTime date);
        Task<List<Order>> GetAllOrder();

    }
}
