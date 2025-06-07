using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    public interface IInventoryDAO
    {
        Task<Inventory> GetByProductIdAsync(int productId);
        Task AddAsync(Inventory inventory);
        Task UpdateAsync(Inventory inventory);
        Task<bool> ExistsAsync(int productId);
        Task<Inventory> GetByInventoryIdAsync(int invId);
        Task<List<Inventory>> GetAllAsync();
    }
}
