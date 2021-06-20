using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers.model
{
    /// <summary>
    /// Класс Защитник
    /// </summary>
    public class Defender
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
        /// Клуб футболиста
        /// </summary>
        public string club { get; set; }
        /// <summary>
        /// Удар головой
        /// </summary>
        public int heading { get; set; }
        /// <summary>
        /// Опека
        /// </summary>
        public int opeka { get; set; }
        /// <summary>
        /// Отбор
        /// </summary>
        public int otbor { get; set; }
        /// <summary>
        /// Сила
        /// </summary>
        public int strenght { get; set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public int cost { get; set; }

        // конструктор без id
        public Defender(string name, string lastname, string club, int heading, int opeka, int otbor, int strenght, int speed, int cost)
        {
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.heading = heading;
            this.opeka = opeka;
            this.otbor = otbor;
            this.strenght = strenght;
            this.speed = speed;
            this.cost = cost;
        }

        // конструктор с id
        public Defender(int id, string name, string lastname, string club, int heading, int opeka, int otbor, int strenght, int speed, int cost)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.heading = heading;
            this.opeka = opeka;
            this.otbor = otbor;
            this.strenght = strenght;
            this.speed = speed;
            this.cost = cost;
        }
    }
}
