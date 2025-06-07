using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_class
{
    class StoreManage : Employee
    {
        public override string Role
        {
            get => base.name + "StoreManage";
            set => base.name = value;
        }
        public StoreManage() {}
        public StoreManage(string workPlace, int shift, double salary, string name, DateTime birth, string gender,
            string address, string phone, string userName, string password) : base(workPlace, shift, salary,
                name, birth, gender, address, phone, userName, password)
        { }
    }
}
