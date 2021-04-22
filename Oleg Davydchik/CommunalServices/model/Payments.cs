using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class Payments
    {
        public int id { get; set; }
        public DateTime deadline { get; set; }
        public int consumerCardId { get; set; }
        public float payed { get; set; }

        public Payments(int id, DateTime deadline, int consumerCardId, float payed)
        {
            this.id = id;
            this.deadline = deadline;
            this.consumerCardId = consumerCardId;
            this.payed = payed;
        }

    }
}
