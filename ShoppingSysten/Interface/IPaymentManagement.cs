using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    internal interface IPaymentManagement
    {
        Task<Payment> Process(Order order, PaymentMethod method);
    }
}
