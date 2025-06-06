﻿using System;

namespace Entity_class

{
    public class Inventory
	{
		public int productId { get; set; }
		public int inventoryId { get; set; }
		public int Quantity { get; set; }
		public decimal ReorderLevel { get; set; }
		public DateTime ExpriryDate { get; set; }
		public DateTime lastUpdate { get; set; }
        public Inventory()
        {
            lastUpdate = DateTime.Now;
        }
        public Inventory(int ProductId, int initialQuantity, int ReorderQuantity, DateTime date) 
		{
			productId = ProductId;
			Quantity = initialQuantity;
			ReorderLevel = ReorderQuantity;
			ExpriryDate = date;
			lastUpdate = DateTime.Now;
		}
		//Khi hàng dưới 50 thì cần nhập hàng lại
		public bool NeedRestock() => Quantity <= ReorderLevel - 50;

	}
}