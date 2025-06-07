using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_class
{
    class Customer : human
    {
        [Key] public int CustomerId { get; set; }
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
