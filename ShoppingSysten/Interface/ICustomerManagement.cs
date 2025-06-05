using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;

namespace ShoppingSysten.Interface
{
    internal interface ICustomerManagement
    {
        Task AddShoppingCart(ShoppingCart cart);
        Task DeleteShoppingCart(ShoppingCart cart);
        //tìm sản phẩm đã từng mua
        Task FindProduct(string productId);
        Task<IEnumerable<ShoppingCart>> GetAllProducts();
    }
}
