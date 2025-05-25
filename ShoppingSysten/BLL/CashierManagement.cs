using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inforProduct;
using pbl.Manager.Interface;
using pbl.Manager.Entity;
using inforProduct;

namespace pbl.Manager.BLL
{
    public class CashierManagement : ICashier
    {
        private readonly List<Bill> _bills;

        public CashierManagement()
        {
            _bills = new List<Bill>();
        }

        public async Task<bool> AddBill(Bill bill)
        {
            // Implementation for adding a bill
            // This is a placeholder implementation
            if (bill == null)
            {
                return await Task.FromResult(false);
            }
            else
            {
                
            }
            return await Task.FromResult(true);
        }

        public async Task<Bill> GetBillById(int id)
        {
            // Implementation for getting a bill by ID
            return await Task.FromResult(_bills.FirstOrDefault(b => b.Id == id));
        }

        public async Task<Bill> GetBillByEmployeeId(int employeeId)
        {
            // Implementation for getting a bill by employee ID
            return await Task.FromResult(_bills.FirstOrDefault(b => b.EmployeeId == employeeId));
        }
    }
}