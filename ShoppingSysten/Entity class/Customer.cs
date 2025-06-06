using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_class
{
    class Customer : human
    {
        public int CustomerId;
        public double score { get; set; }

        public Customer() {
            score = 0;
        }
        public Customer(double score, string name, DateTime birth, string gender,
            string address, string phone, string userName,
            string password) : base( name,  birth,  gender,
                address,  phone,  userName, password)
        {
            this.score = score;
        }
    }
}
