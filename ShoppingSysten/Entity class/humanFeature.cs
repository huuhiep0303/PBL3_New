using System;

namespace Entity_class
{
    public class human
    {
        public string name { get; set; }
        public DateTime birth { get; set; }
        public string gender { set; get; }
        public string address { get; set; }
        public string phone { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public human()
        {
            name = "";
            birth = new DateTime(0, 0, 0);
            gender = "";
            address = "";
            phone = "";
            userName = "";
            password = "";
        }
        public human( string name, DateTime birth, string gender, string address, string phone, string userName, string password)
        {
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
