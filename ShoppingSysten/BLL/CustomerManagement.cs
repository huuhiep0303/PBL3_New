using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Entity_class;

namespace BLL
{
    class CustomerManagement : ICustomerManagement
    {
        private readonly ICustomerManagement cmCustomer;
        private readonly IProductManagement pmProduct;
        private readonly IOrderManagement orderManagement;
        private readonly IOrderDAO _repo;
        public CustomerManagement(ICustomerManagement cmCustomer, IProductManagement productManagement, IOrderDAO repo)
        {
            this.cmCustomer = cmCustomer;
            this.pmProduct = productManagement;
            _repo = repo;
        }
        public async Task<ShoppingCart> AddShoppingCart(ShoppingCart cart)
        {
            return await cmCustomer.AddShoppingCart(cart);
        }
        public async Task<int> DeleteShoppingCart(ShoppingCart cart)
        {
            return await cmCustomer.DeleteShoppingCart(cart);
        }
        //tìm sản phẩm đã từng mua
        public async Task<int> FindProduct(int productId, List<product> items) 
        {
            foreach (var productID in items)
            {
                var product = await pmProduct.GetProductById(productId);
                if (product != null)
                {
                    Console.WriteLine("Tên sản phẩm: {0}", product.name_product);
                    Console.WriteLine("Số lượng: {0}", product.stockQuantity);
                    Console.WriteLine("Giá sản phẩm: {0}", product.price);
                    return 1;
                }
            }
            return 0;
        }
        public async Task<List<product>> GetAllProducts()
        {
            return await pmProduct.GetAllProductsAsync();
        }
        public async Task<List<Order>> GetAllOrder()
        {
            return await _repo.GetAllOrders();    
        }
    }
}
