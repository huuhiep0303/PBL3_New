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
        public CustomerManagement(ICustomerManagement cmCustomer,
            IProductManagement productManagement,
            IOrderDAO repo, IOrderManagement orderManagement)
        {
            this.cmCustomer = cmCustomer;
            this.pmProduct = productManagement;
            _repo = repo;
            this.orderManagement = orderManagement;
        }
        public async Task AddOrder(Order order)
        {
            if (order == null || order.Items == null || order.Items.Count == 0)
            {
                Console.WriteLine("❌ Đơn hàng không hợp lệ.");
            }

            order.OrderDate = DateTime.Now;
            order.status = Status.Pending; // hoặc giá trị mặc định phù hợp

            await _repo.InsertOrder(order); // gọi DAO để lưu vào DB

            Console.WriteLine("✅ Đã thêm đơn hàng cho khách hàng ID: " + order.CustomerId);
        }

        public async Task<int> DeleteOrder(Order order)
        {
            try
            {
                await _repo.DeleteOrder(order.OrderId); // gọi DAO xoá
                Console.WriteLine("✅ Đã xoá đơn hàng có ID = " + order.OrderId);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi xoá đơn hàng: " + ex.Message);
                return 0;
            }
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
        public async Task<List<Order>> GetAllOrderOfCustomer(int customerId)
        {
            var list = await _repo.GetAllOrdersById(customerId);
            foreach (var order in list)
            {
                Console.WriteLine(order.CustomerId);
                Console.WriteLine(order.OrderId);
                Console.WriteLine(order.OrderDate);
                Console.WriteLine(order.Items);
            }
            return list;
        }
    }
}
