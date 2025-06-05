using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace ShoppingSysten.Entity_class
{
    class Cashier : Employee
    {
        public List <Order> orders;
        public Cashier()
        {
            orders = new List<Order>();
        }
    }
}
