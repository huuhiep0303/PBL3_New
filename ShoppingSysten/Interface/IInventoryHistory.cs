using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_class;

namespace Interface
{
    internal interface IInventoryHistory
    {
        Task AddTransaction(InventoryTransaction transaction);
        Task<List<InventoryTransaction>> GetHistoryByProductId(int productID);
        Task Display(int p);
        Task DeleteHistoryByTransactionId(int tranId);
        Task DeleteHistoryByProductId(int productID);
        

    }
}
