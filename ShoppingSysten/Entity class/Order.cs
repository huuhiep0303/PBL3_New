﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSysten.Entity_class
{
    public enum Status { Pending, Completed, Canceled}
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Status status { get; set; }
        public decimal OrderTotal => Items.Sum(p => p.Total);
        public Order() { }
        public Order(int customerId)
        {
            CustomerId = customerId;
            OrderDate = DateTime.Now;
            status = Status.Pending;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void DisplayOrder()// kiểm tra thôi
        {
            Console.WriteLine($"🧾 Đơn hàng #{OrderId} - Khách: {CustomerId} - Ngày: {OrderDate} - Trạng thái đơn hàng: {status}");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item.ProductName} x{item.Quantity} = {item.Total}đ");
            }
            Console.WriteLine($"Tổng cộng: {OrderTotal}đ");
            Console.WriteLine($"Trạng thái đơn hàng: {status}");
        }
        public void UpdateStatus(Status st)
        {
            status = st;

        }
    }
}
