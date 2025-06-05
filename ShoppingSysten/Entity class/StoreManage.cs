using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;

namespace ShoppingSysten.Entity_class
{
    class StoreManage : Employee
    {
        public List<product> products;
        public StoreManage() 
        { 
            products = new List<product>();
        }
        public StoreManage(List<product> products)
        {
            this.products = products;
        }
    }
}
