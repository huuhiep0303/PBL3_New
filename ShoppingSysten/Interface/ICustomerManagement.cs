using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface 
{ 
     internal interface ICustomerManagement
    {
        Task<ShoppingCart> AddShoppingCart(ShoppingCart cart);
        Task<int> DeleteShoppingCart(ShoppingCart cart);
        //tìm sản phẩm đã từng mua
        Task<int> FindProduct(int productId,List<product> items);
        Task<List<product>> GetAllProducts();
        Task<List<Order>> GetAllOrderOfCustomer(int customerId);
    }
}