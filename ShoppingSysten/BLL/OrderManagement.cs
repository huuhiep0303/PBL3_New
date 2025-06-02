using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;
using Interface;

namespace BLL 
{
    internal class OrderManagement : IOrderManagement
    {
        private readonly IInventoryManagement imService;
        private readonly IProductManagement pmService;
        private readonly IOrderDAO _repo;

        public OrderManagement(IProductManagement pmService, IInventoryManagement imService, IOrderDAO repo)
        {
            this.imService = imService;
            this.pmService = pmService;
            _repo = repo;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _repo.GetOrderById(id);
        }
        public async Task<List<Order>> GetOrderByDateTime(DateTime date)
        {
            return await _repo.GetOrdersByDate(date);
        }

        //khi khách hoặc nhân viên xác nhận những gì đã mua, gọi hàm này để tạo đơn hàng 
        public async Task<Order> CreateOrder(int customerId, List<(int productID,int quantity)> items)
        {
            var order = new Order(customerId);

            foreach (var (productID, quantity) in items)
            {
                var product = await pmService.GetProductById(productID);
                if (product == null || !await imService.ReduceOrSaleStock(productID, quantity, "SALE"))
                {
                    Console.WriteLine("Sản phẩm không hợp lệ hoặc hết hàng.");
                    return null;
                }
                order.AddItem(new OrderItem(productID, product.name_product, product.price, quantity));
            }

            order.OrderDate = DateTime.Now;
            order.status = Status.Pending;

            int newId = await _repo.InsertOrder(order);
            order.OrderId = newId;

            foreach (var item in order.Items)
            {
                await _repo.InsertOrderItem(newId, item);
            }

            Console.WriteLine("Tạo đơn thành công!");
            return order;

        }
        public async Task DisplayAllOrder()
        {
            //    foreach (var order in orders)
            //    {
            //        order.DisplayOrder();
            //    }
            //    return;
        }
        public async Task DisplayOrderByDate(DateTime date)
        {
            var orderdate = await GetOrderByDateTime(date);
            foreach (var item in orderdate)
            {
                item.DisplayOrder();
            }
            return;
        }
        public async Task<bool> DeleteOrder(int orderID)
        {
            return await _repo.DeleteOrder(orderID);
        }
        public async Task<bool> CancelOrder(int orderID)
        {
            var order = await _repo.GetOrderById(orderID);
            if (order == null)
            {
                Console.WriteLine("Không thấy đơn hàng!");
                return await Task.FromResult(false);

            }
            foreach (var item in order.Items)
            {
                bool restored = await imService.RestoreStock(item.ProductId, item.Quantity);
                if (!restored)
                {
                    Console.WriteLine("Không thể phục hồi hàng");
                    return await Task.FromResult(false);
                }
            }
            order.status = Status.Canceled;
            Console.WriteLine($"Đơn hàng {order.OrderId} đã bị hủy!");
            return await Task.FromResult(true);

        }
        public async Task CancelOverDueOrder(TimeSpan ts)
        {
            var now = DateTime.Now;
            var orders = await _repo.GetAllOrders();
            var order = orders.Where(o => o.status == Status.Pending && now - o.OrderDate > ts).ToList();
            foreach (var item in order)
            {
                bool canceled = await CancelOrder(item.OrderId);
                if (canceled)
                {
                    Console.WriteLine("Quá thời gian , tự động hủy!");
                }
            }
        }
    }
}
