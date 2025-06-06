using System;
using System.Windows.Forms;

namespace Formemployee
{
    public partial class formemployee : Form
    {
        public formemployee()
        {
            InitializeComponent();
        }

        private void formemployee_Load(object sender, EventArgs e)
        {

            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = false;
            uC_Nhacungcap1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Hoadon1.Visible = false;
            uC_Quanlykho1.Visible = false;


            // Thiết lập và khởi động đồng hồ
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        // Ẩn tất cả UserControl
       

        private void button5_Click(object sender, EventArgs e)
        {
            uC_Banhang1.Visible = true;
            uC_Sanpham1.Visible = false;
            uC_Nhacungcap1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Hoadon1.Visible = false;
            uC_Quanlykho1.Visible = false;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            uC_Nhacungcap1.Visible = true;
            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Hoadon1.Visible = false;
            uC_Quanlykho1.Visible = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            uC_Hoadon1.Visible = true;
            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = false;
            uC_Nhacungcap1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Quanlykho1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_Thongke1.Visible = true;
            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = false;
            uC_Nhacungcap1.Visible = false;
            uC_Hoadon1.Visible = false;
            uC_Quanlykho1.Visible = false;


        }

        // Các sự kiện không cần thiết có thể để trống hoặc xóa nếu không dùng
        private void lblTime_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e)
        {
            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = true;
            uC_Nhacungcap1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Hoadon1.Visible = false;
            uC_Quanlykho1.Visible = false;


        }
        private void uC_Thongke1_Load(object sender, EventArgs e) { }
        private void uC_Sanpham1_Load(object sender, EventArgs e) { }
        private void uC_Nhacungcap1_Load(object sender, EventArgs e) { }

        private void uC_Thongke1_Load_1(object sender, EventArgs e)
        {

        }

        private void uC_Nhacungcap1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_Quanlykho1.Visible = true;
            uC_Banhang1.Visible = false;
            uC_Sanpham1.Visible = false;
            uC_Nhacungcap1.Visible = false;
            uC_Thongke1.Visible = false;
            uC_Hoadon1.Visible = false;

        }
    }
}
