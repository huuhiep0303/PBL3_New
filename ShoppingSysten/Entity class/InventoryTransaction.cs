using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_class
{
    public class InventoryTransaction
    {
        public int TransactionId { get; set; }//TransactionId INT PRIMARY KEY IDENTITY(1,1), -- Tự tăng
        public int ProductId { get; set; }
        public string ActionType { get; set; } // (Import, Reduce, Return, Sale) để enum sau vậy

        public int QuantityChanged { get; set; }
        public DateTime ChangedTime { get; set; }// ngày nhập hàng hoặc xuất j đó
        public string note { get; set; }// ghi chú kèm theo

        public InventoryTransaction()
        {
            ChangedTime = DateTime.Now;
        }
        public InventoryTransaction(int productId, string actionType, int quantityChanged, string note ="") : this()
        {
            ProductId = productId;
            ActionType = actionType;
            QuantityChanged = quantityChanged;
            ChangedTime = DateTime.Now;
            this.note = note;
        }
    }
}
