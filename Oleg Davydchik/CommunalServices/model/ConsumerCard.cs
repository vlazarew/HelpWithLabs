﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class ConsumerCard
    {
        public int id { get; set; }
        public int dateOfPay { get; set; }
        public int consumerId { get; set; }
        public int typeOfServiceId { get; set; }

    }
}
