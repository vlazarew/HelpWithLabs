using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    public class TypeOfService
    {
        public int id { get; set; }
        public string name { get; set; }

        public float cost { get; set; }


        public TypeOfService(int id, string name, float cost)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
        }

        public TypeOfService(string name, float cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
