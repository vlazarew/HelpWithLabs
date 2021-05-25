using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.model
{
    public class Building
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public string location { get; set; }
        public string condition { get; set; }
        public int contractId { get; set; }
        public string team { get; set; }


        public Building(int id, string name, string type, int year, string location, string condition, int contractId, string team)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.year = year;
            this.location = location;
            this.condition = condition;
            this.contractId = contractId;
            this.team = team;
        }

        public Building(string name, string type, int year, string location, string condition, int contractId, string team)
        {
            this.name = name;
            this.type = type;
            this.year = year;
            this.location = location;
            this.condition = condition;
            this.contractId = contractId;
            this.team = team;
        }
    }
}
