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

        public PhoneRegister(string FIO, string phone)
        {
            this.FIO = FIO;
            this.phone = phone;
        }

        public PhoneRegister(int id, string FIO, string phone)
        {
            this.id = id;
            this.FIO = FIO;
            this.phone = phone;
        }
    }
}
