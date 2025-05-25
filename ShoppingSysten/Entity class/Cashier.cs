using humanFeature;
using inforProduct;
using System;
using System.Collections.Generic;
using Employee;
using pbl.entity_class
namespace pbl.Manager.Entity
{
    public class Cashier : EmployeeObject
    {
        protected List<Bill> BillList;
        protected List<double> TotalPriceList;
        public Cashier()
        {
            BillList = new List<Bill>();
            TotalPriceList = new List<double>();
        }
    }
}