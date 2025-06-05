using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSysten.Entity_class
{
    class Admin : Employee
    {
        List <Employee> employees;
        List <Order> orders;
        Admin(List<Employee> employees, List<Order> orders)
        {
            this.employees = employees;
            this.orders = orders;
        }
        Admin()
        {
            employees = new List<Employee>();
            orders = new List<Order>();
        }
    }
}
