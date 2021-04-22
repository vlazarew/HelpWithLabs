using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Вид сервиса
    /// </summary>
    public class TypeOfService
    {
        // id вид сервиса
        public int id { get; set; }
        // Наименование
        public string name { get; set; }
        // Стоимость
        public float cost { get; set; }

        /// <summary>
        /// Конструктор с id
        /// </summary>
        /// <param name="id">id вид сервиса</param>
        /// <param name="name">Наименование</param>
        /// <param name="cost">Стоимость</param>
        public TypeOfService(int id, string name, float cost)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
        }

        /// <summary>
        /// Конструктор без id
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="cost">Стоимость</param>
        public TypeOfService(string name, float cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
