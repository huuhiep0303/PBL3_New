using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    interface IStoreManagement
    {
        Task<List<product>> GetAllProduct();
        Task <product> GetProductById(int id);
        Task DeleteProductById(int id);
        Task InserProduct(product product);
        Task UpdateInforProduct(int productId);
    }
}
