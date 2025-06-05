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
        public Employee() 
        { 
            Shift = 0;
            Salary = 0;
        }
        public Employee(Location workPlace, int shift, double salary)
        {
            WorkPlace = workPlace;
            Shift = shift;
            Salary = salary;
        }
    }
}
