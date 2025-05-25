using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inforProduct;

namespace pbl.Manager.Interface
{ 
    internal interface ICashier
    {
        Task<bool> AddBill(employee emp);
        Task<Bill> GetBillById(int id);
        Task<Bill> GetBillByEmployeeId(int employeeId);
    }
}
