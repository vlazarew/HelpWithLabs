using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.model
{
    public class PhoneRegister
    {
        public int id { get; set; }
        public string FIO { get; set; }
        public string phone { get; set; }
        public string companyName{ get; set; }
        public string mail{ get; set; }


        public PhoneRegister(string FIO, string phone, string companyName, string mail)
        {
            this.FIO = FIO;
            this.phone = phone;
            this.companyName = companyName;
            this.mail = mail;
        }

        public PhoneRegister(int id, string FIO, string phone, string companyName, string mail)
        {
            this.id = id;
            this.FIO = FIO;
            this.phone = phone;
            this.companyName = companyName;
            this.mail = mail;
        }
    }
}
