
using System;
using System.Collections.Generic;
using entity_class;
//cập nhật list của mỗi đối tượng sau mỗi lần cập nhật trên API.
// Mỗi lần tính tiền thì lấy một mảng tạm thời để đem ra tính.
//Lấy biến tạm để lấy dữ liệu từ cơ sở dữ liệu
namespace entity_class
{
    public class Customer : human
    {
        public int CustomerId { get; set; }
        public List<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
            
        }

        
        public void register()
        {
            //Cái này là lớp đa hình do khách hàng và nhân viên đều có chung nên sẽ thêm môt số thành phần sau
            //Mã khách hàng sẽ được gán cho giá trị biến đếm là count với kiểu static tăng dần với mỗi khách
            Console.WriteLine("Tên cá nhân: ");
            this.name = Console.ReadLine();
            Console.WriteLine("Ngày sinh: ");
            //birth.getDate();
            Console.WriteLine("Giới tính: ");
            this.gender = Console.ReadLine();
            Console.WriteLine("Địa chỉ: ");
            address.getAddress();
            Console.WriteLine("Số điện thoại: ");
            this.phone = Console.ReadLine();
            Console.WriteLine("Nhập tên tài khoản: ");
            this.userName = Console.ReadLine();
            Console.WriteLine("Nhập mật khẩu: ");
            this.password = Console.ReadLine();
            string check_password;
            Console.WriteLine("Nhập lại mật khẩu: ");
            check_password = Console.ReadLine();
            while (this.password != check_password)
            {
                Console.WriteLine("Mật khẩu không khớp, vui lòng nhập lại: ");
                Console.WriteLine("Nhập mật khẩu: ");
                this.password = Console.ReadLine();
                Console.WriteLine("Nhập lại mật khẩu: ");
                check_password = Console.ReadLine();
            }
            //cần tạo một hàm để kiểm tra thử tài khoản này có tồn tại hay chưa
        }

        public void login()
        {
            Console.WriteLine("Nhập tên tài khoản: ");
            this.userName = Console.ReadLine();
            Console.WriteLine("Nhập mật khẩu: ");
            this.password = Console.ReadLine();
            //cần tạo một hàm để kiểm tra thử tài khoản này có tồn tại hay chưa
        }

        public void logout()
        {
            Console.WriteLine("Đăng xuất thành công");
        }


    }
}