using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_class;

namespace Interface
{
    public interface IHistoryDAO
    {
        Task<List<InventoryTransaction>> GetHistoryByProductIdAsync(int productId);
        Task AddTransactionAsync(InventoryTransaction transaction);
        Task DeleteByTransactionIdAsync(int tranId);
        Task DeleteByProductIdAsync(int productId);

    }
}
