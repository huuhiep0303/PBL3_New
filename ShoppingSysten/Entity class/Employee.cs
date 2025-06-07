using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entity_class
{
    class Employee : human
    {
        [Key] public int customerId { get; set; }
        public virtual string Role { set; get; }
        public string WorkPlace { get; set; }
        public int Shift {  get; set; }
        public double Salary { get; set; }
        public Employee() 
        {
            WorkPlace = " ";
            Shift = 0;
            Salary = 0;
        }
        public Employee(string workPlace, int shift, double salary, string name, DateTime birth, string gender, string address, string phone, string userName, string password) : base( name, birth, gender, address, phone, userName, password)
        {
            WorkPlace = workPlace;
            Shift = shift;
            Salary = salary;
        }
    }
}
