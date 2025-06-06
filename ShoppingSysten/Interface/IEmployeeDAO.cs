using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace ShoppingSysten.Interface
{
    internal interface IEmployeeDAO
    {
        Task<int> InsertEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int employeeId);
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> GetAllEmployee();


    }
}
