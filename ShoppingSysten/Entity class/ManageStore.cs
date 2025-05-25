using humanFeature;
using inforProduct;
using System;
using System.Collections.Generic;
using Employee;
namespace pbl.Manager.Entity
{
    public class ManageStore : Employee
    {
        protected List<string> productList;
        protected List<double> price;
        protected List<int> quantity;
        //ngày sản xuất
        protected List<DateTime> productDate;
        //ngày hết hạn
        protected List<DateTime> expirationDate;
        protected List<string> supplier;

        public ManageStore()
        {
            this.salary = 0;
            this.shift = 0;
            this.productList = new List<string>();
            this.price = new List<double>();
            this.quantity = new List<int>();
            this.productDate = new List<DateTime>();
            this.expirationDate = new List<DateTime>();
            this.supplier = new List<string>();
        }

        public ManageStore(double salary, int shift)
        {
            this.salary = salary;
            this.shift = shift;
        }
        public void addProduct(string product, double price, int quantity)
            {
                this.productList.Add(product);
                this.price.Add(price);
                this.quantity.Add(quantity);
            }
    }
}