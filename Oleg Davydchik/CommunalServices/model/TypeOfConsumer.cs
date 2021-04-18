using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class TypeOfConsumer
    {
        public int id { get; set; }
        public string name { get; set; }

        public TypeOfConsumer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
