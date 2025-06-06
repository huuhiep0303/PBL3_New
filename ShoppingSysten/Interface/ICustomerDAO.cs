using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    interface ICustomerDAO
    {
        Task <int> InsertCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int customerId);
        Task<Customer> GetCustomerById(int customerId);
    }
}
