using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace ShoppingSysten.Entity_class
{
    class Customer : human
    {
        public ShoppingCart cart { get ; set; }
        public double score { get; set; }

        public Customer() {
            cart = new ShoppingCart();
            score = 0;
        }
        public Customer(double score)
        {
            cart = new ShoppingCart();
        }
    }
}
