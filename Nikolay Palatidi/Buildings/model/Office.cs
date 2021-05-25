using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.model
{
    class Office
    {
        public int id { get; set; }
        public string buildingNames { get; set; }
        public string payment { get; set; }
        public string name { get; set; }
        public int contractId { get; set; }

        public Office(int id, string buildingNames, string payment, string name, int contractId)
        {
            this.id = id;
            this.buildingNames = buildingNames;
            this.payment = payment;
            this.name = name;
            this.contractId = contractId;
        }

        public Office(string buildingNames, string payment, string name, int contractId)
        {
            this.buildingNames = buildingNames;
            this.payment = payment;
            this.name = name;
            this.contractId = contractId;
        }
    }
}
