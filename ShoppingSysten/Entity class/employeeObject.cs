using humanFeature;
using inforProduct;
using System;
using System.Collections.Generic;   

namespace Employee
{
    public class EmployeeObject : human
    {
        protected double salary;
        protected int shift;//shift: ca làm việc
        protected Location workPlace;
        protected DateTime workDate;
        public EmployeeObject()
        {
            salary = 0;
            shift = 0;
            workDate = new DateTime(0, 0, 0);
        }

        public EmployeeObject(double salary, int shift, Location workPlace, DateTime workDate)
        {
            this.salary = salary;
            this.shift = shift;
            this.workPlace = workPlace;
            this.workDate = workDate;
        }

        class ManageStore : EmployeeObject
        {
            protected List<string> productList;
            protected List<double> price;
            protected List<int> quantity; 
            //ngày sản xuất
            protected List<DateTime> productDate;
            //ngày hết hạn
            protected List<DateTime> expirationDate;
            protected List<string> supplier;
            //trong thư viện date có gì

            public ManageStore()
            {
                this.salary = 0;
                this.shift = 0;
                this.productList = new List<string>();
                this.price = new List<double>();
                this.quantity = new List<int>();
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

            public void removeProduct(string product)
            {
                for (int i = 0; i < this.productList.Count; i++)
                {
                    if (this.productList[i] == product)
                    {
                        this.productList.RemoveAt(i);
                        this.price.RemoveAt(i);
                        this.quantity.RemoveAt(i);
                        break;
                    }
                }
            }

            //lấy hàng của kho hay là gửi thông báo tới quản lí kho
            public void takeProduct(string product, int quantity)
            {
                for (int i = 0; i < this.productList.Count; i++)
                {
                    if (this.productList[i] == product)
                    {
                        this.quantity[i] -= quantity;
                        break;
                    }
                }
            }
        }
    }
}

       
