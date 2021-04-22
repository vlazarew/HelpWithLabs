using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class PhoneNumber
    {
        public int consumerId { get; set; }
        public string value { get; set; }

        public PhoneNumber(string number)
        {
            this.value = number;
        }

        public PhoneNumber(string number, int consumerId)
        {
            this.consumerId = consumerId;
            this.value = number;
        }

    }
}
