using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inforProduct;

namespace pbl.Manager.Interface
{ 
    internal interface IEmployeeManagement
    {
        Task<bool> AddEmployee(employee emp);
        Task<employee> GetEmployeeById(int id);
        Task<employee> GetEmployeeByName(string name);
        Task<List<employee>> SearchEmployee(string keyword);
        Task<List<employee>> GetAllEmployees();
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(int id, string newName, string newDesc);
        Task<bool> IsEmployeeExist(int employeeId);
    }
}