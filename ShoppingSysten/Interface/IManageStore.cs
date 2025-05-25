using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inforProduct;

namespace pbl.Manager.Interface
{
    internal interface IManageStore
    {
        Task<bool> AddProduct(product product);
        Task<product> GetProductById(int id);
        Task<product> GetProductByName(string name);
        Task<product> takeProduct(int ID_product, ỉnt quantity);
        Task<List<product>> SearchProduct(string keyword);
        Task<List<product>> GetAllProducts();
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, string newName, string newDesc, double newPrice, int newQuantity);
        Task<bool> IsProductExist(int productId);
    }
}