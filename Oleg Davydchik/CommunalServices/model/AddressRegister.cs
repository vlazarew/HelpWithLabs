using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    public class AddressRegister
    {
        public int id { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public int flat { get; set; }

        public AddressRegister(string street, string house, int flat)
        {
            this.street = street;
            this.house = house;
            this.flat = flat;
        }

        public AddressRegister(int id, string street, string house, int flat)
        {
            this.id = id;
            this.street = street;
            this.house = house;
            this.flat = flat;
        }
    }
}
