using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayers.model
{
    /// <summary>
    /// Класс полузашитние
    /// </summary>
    public class Midfielder
    {
        /// <summary>
        /// id записи
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
        public string lastname { get; set; }
        /// <summary>
        /// клуб
        /// </summary>
        public string club { get; set; }
        /// <summary>
        /// дриблинг
        /// </summary>
        public int dribbling { get; set; }
        /// <summary>
        /// пас
        /// </summary>
        public int pass { get; set; }
        /// <summary>
        /// техника
        /// </summary>
        public int technical { get; set; }
        /// <summary>
        /// ловкость
        /// </summary>
        public int agility { get; set; }
        /// <summary>
        /// скорость
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// стоимость
        /// </summary>
        public int cost { get; set; }

        // конструктор без id 
        public Midfielder(string name, string lastname, string club, int dribbling, int pass, int technical, int agility, int speed, int cost)
        {
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.dribbling = dribbling;
            this.pass = pass;
            this.technical = technical;
            this.agility = agility;
            this.speed = speed;
            this.cost = cost;
        }

        // конструктор с id
        public Midfielder(int id, string name, string lastname, string club, int dribbling, int pass, int technical, int agility, int speed, int cost)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.club = club;
            this.dribbling = dribbling;
            this.pass = pass;
            this.technical = technical;
            this.agility = agility;
            this.speed = speed;
            this.cost = cost;
        }

    }
}
