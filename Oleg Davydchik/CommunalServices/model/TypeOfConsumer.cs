using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Тип клиента
    /// </summary>
    class TypeOfConsumer
    {
        // id типа клиента
        public int id { get; set; }
        // Наименование типа
        public string name { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">id типа клиента</param>
        /// <param name="name">Наименование типа</param>
        public TypeOfConsumer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
