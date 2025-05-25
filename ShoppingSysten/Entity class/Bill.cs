using System;
using System.ComponentModel.DataAnnotations;
using pbl.entity_class;
using inforProduct;
using System.Collections.Generic;

namespace pbl.Manager.Entity
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        List<product> productList;
        List<int> quantityList;
        public DateTime BillDate { get; set; }
        public int ID_Cusotmer { get; set; }
        public string CustomerName { get; set; }
        public Payment payment { get; set; }
        public double 

        public Bill(int orderId, decimal totalAmount, string customerName)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
            CustomerName = customerName;
            BillDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"BillId: {BillId}, OrderId: {OrderId}, TotalAmount: {TotalAmount:C}, " +
                   $"CustomerName: {CustomerName}, BillDate: {BillDate}";
        }
    }
}