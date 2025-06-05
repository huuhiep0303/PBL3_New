using System;

namespace ShoppingSysten.Entity_class
{
    public class Location
    {
        protected string street { get; set; }
        protected string city { get; set; }
        protected string country { get; set; }
        protected Location()
        {
            street = "";
            city = "";
            country = "";
        }
        protected Location(string street, string city, string country)
        {
            this.street = street;
            this.city = city;
            this.country = country;
        }
        ~Location() { }

        public void getAddress()
        {
            Console.WriteLine("Nhập địa chỉ: ");
            Console.WriteLine("Số nhà: ");
            this.street = Console.ReadLine();
            Console.WriteLine("Thành phố: ");
            this.city = Console.ReadLine();
            Console.WriteLine("Quốc gia: ");
            this.country = Console.ReadLine();
        }
        public void startAddress() //khởi tạo giá trị cho lớp dùng quan hệ has is
        {
            street = "";
            city = "";
            country = "";
        }
    };
    public class human
    {
        protected readonly int ID;
        public human (int ID)
        {
            this.ID = ID;
        }
        protected string name { get; set; }
        protected DateTime birth { get; set; }
        protected string gender { set; get; }
        protected Location address { get; set; }
        protected string phone { get; set; }
        protected string userName { get; set; }
        protected string password { get; set; }
        public human()
        {
            ID = 0;
            name = "";
            birth = new DateTime(0, 0, 0);
            gender = "";
            address.startAddress();
            phone = "";
            userName = "";
            password = "";
        }
        public human(int ID, string name, DateTime birth, string gender, Location address, string phone, string userName, string password)
        {
            this.ID = ID;
            this.name = name;
            this.birth = birth;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.userName = userName;
            this.password = password;
        }
    };
}
