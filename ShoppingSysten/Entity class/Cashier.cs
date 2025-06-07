using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Entity_class
{
    class Cashier : Employee
    {
        public string Role = "Cashier";
        public Cashier(){ }
        public Cashier(string workPlace, int shift, double salary, string name, DateTime birth, string gender,
            string address, string phone, string userName, string password) : base(workPlace, shift, salary,
                name, birth, gender, address, phone, userName, password)  { }
    }
}
