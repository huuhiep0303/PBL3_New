﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSysten.Entity_class;
namespace Interface
{
    internal interface IInventoryManagement
    {
        Task<bool> CreateRecord(int productId, int initialQuantity, int reorderQuantity);
        Task<bool> ImportOrReturnStock(int productId, int amount,string actionType);
        Task<bool> ReduceOrSaleStock(int productId, int amount, string actionType);
        Task<Inventory> GetInventoryById(int inventoryId);
        Task<bool> RestoreStock(int productID, int amount);
        Task DisplayLowStockProductsAsync();
    }
}
