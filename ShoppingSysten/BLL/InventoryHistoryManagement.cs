using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.DAO;
using ShoppingSysten.Entity_class;
using Interface;


namespace BLL
{
    internal class InventoryHistoryManagement : IInventoryHistory
    {
        private readonly IHistoryDAO _repo;
        public InventoryHistoryManagement(string connectionString)
        {
            _repo = new InventoryHisDAO(connectionString);
        }
        public async Task AddTransaction(InventoryTransaction transaction)
        {
            await _repo.AddTransactionAsync(transaction);
            Console.WriteLine("Thêm lịch sử thành công");
        } 
        public async Task<List<InventoryTransaction>> GetHistoryByProductId(int productID)
        {
            return await _repo.GetHistoryByProductIdAsync(productID);
        }
        public async Task Display(int productId)
        {
            var list = await _repo.GetHistoryByProductIdAsync(productId);
            if (list.Count == 0)
            {
                Console.WriteLine("Không có lịch sử.");
                return;
            }

            Console.WriteLine("Lịch sử giao dịch:");
            foreach (var h in list)
            {
                Console.WriteLine($"- [{h.ChangedTime}] SP: {h.ProductId}, Hành động: {h.ActionType}, SL: {h.QuantityChanged}, Ghi chú: {h.note}");
            }
        }
        public async Task DeleteHistoryByTransactionId(int tranId)
        {
            await _repo.DeleteByTransactionIdAsync(tranId);
            Console.WriteLine("Đã xóa lịch sử theo Transaction ID");
        }
        public async Task DeleteHistoryByProductId(int id)
        {
            await _repo.DeleteByTransactionIdAsync(id);
            Console.WriteLine("Đã xóa lịch sử theo product ID");
        }
    }
}
