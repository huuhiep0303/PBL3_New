using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;


namespace ShoppingSysten.Entity_class
{
    class StoreManage : Employee
    {
        public List<product> products;
        public StoreManage() 
        { 
            products = new List<product>();
        }

    }
}
