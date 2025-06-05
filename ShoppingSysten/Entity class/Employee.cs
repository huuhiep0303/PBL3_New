using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSysten.Entity_class
{
    class Employee : human
    {
        public Location WorkPlace { get; set; }
        public int Shift {  get; set; }
        public double Salary { get; set; }

    }
}
