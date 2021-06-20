using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers.model
{
    /// <summary>
    /// Класс Нападающий
    /// </summary>
    public class Forward
    {
        /// <summary>
        /// id записи
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Имя футболиста
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Фамилия футболиста
        /// </summary>
        public string lastname { get; set; }
        /// <summary>
        /// Клуб
        /// </summary>
        public string club { get; set; }
        /// <summary>
        /// Атака
        /// </summary>
        public int attacking { get; set; }
        /// <summary>
        /// Удар
        /// </summary>
        public int shooting { get; set; }
        /// <summary>
        /// Техника
        /// </summary>
        public int technical { get; set; }
        /// <summary>
        /// Физика
        /// </summary>
        public int physical { get; set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public int cost { get; set; }

        // конструктор без id
        public Forward(string name, string lastname, string club, int attacking, int shooting, int technical, int physical, int speed, int cost)
        {
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.attacking = attacking;
            this.shooting = shooting;
            this.technical = technical;
            this.physical = physical;
            this.speed = speed;
            this.cost = cost;
        }

        // конструктор с id
        public Forward(int id, string name, string lastname, string club, int attacking, int shooting, int technical, int physical, int speed, int cost)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.attacking = attacking;
            this.shooting = shooting;
            this.technical = technical;
            this.physical = physical;
            this.speed = speed;
            this.cost = cost;
        }

    }
}
