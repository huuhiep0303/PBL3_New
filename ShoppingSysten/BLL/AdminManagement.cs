using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Entity_class;

namespace BLL
{
    class AdminManagement : IAdminManagement
    {
        private readonly ICustomerDAO _customerDAO;
        private readonly IEmployeeDAO _employeeDAO;
        private readonly IOrderDAO _orderDAO;

        public AdminManagement(ICustomerDAO customerDAO, IEmployeeDAO employeeDAO, IOrderDAO orderDAO)
        {
            _customerDAO = customerDAO;
            _employeeDAO = employeeDAO;
            _orderDAO = orderDAO;
        }

        // ✅ Lấy thông tin khách hàng theo ID
        public async Task<List<Customer>> GetInforCustomer(int customerId)
        {
            var customer = await _customerDAO.GetCustomerById(customerId);
            return customer != null ? new List<Customer> { customer } : new List<Customer>();
        }

        // ✅ Lấy thông tin nhân viên theo ID
        public async Task<List<Employee>> GetInforEmployee(int employeeId)
        {
            var emp = await _employeeDAO.GetEmployeeById(employeeId);
            return emp != null ? new List<Employee> { emp } : new List<Employee>();
        }

        // ✅ Lấy đơn hàng theo ID
        public async Task<List<Order>> GetInforOrder(int orderId)
        {
            var order = await _orderDAO.GetOrderById(orderId);
            return order != null ? new List<Order> { order } : new List<Order>();
        }

        // ✅ Xoá nhân viên
        public async Task DeleteEmployee(int employeeId)
        {
            await _employeeDAO.DeleteEmployee(employeeId);
        }

        // ✅ Xoá đơn hàng
        public async Task DeleteOrder(int orderId)
        {
            await _orderDAO.DeleteOrder(orderId);
        }

        // ✅ Lấy danh sách đơn hàng theo ngày
        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            return await _orderDAO.GetOrdersByDate(date);
        }

        // ✅ Lấy toàn bộ đơn hàng
        public async Task<List<Order>> GetAllOrder()
        {
            return await _orderDAO.GetAllOrders();
        }
    }
}
