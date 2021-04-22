﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Класс Адрес
    /// </summary>
    public class AddressRegister
    {
        // id адреса
        public int id { get; set; }
        // улица
        public string street { get; set; }
        // дом
        public string house { get; set; }
        // квартира
        public int flat { get; set; }

        /// <summary>
        /// Конструктор класс без id
        /// </summary>
        /// <param name="street">Улица</param>
        /// <param name="house">Дом</param>
        /// <param name="flat">Квартира</param>
        public AddressRegister(string street, string house, int flat)
        {
            this.street = street;
            this.house = house;
            this.flat = flat;
        }

        /// <summary>
        /// Конструктор класс с id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="street">Улица</param>
        /// <param name="house">Дом</param>
        /// <param name="flat">Квартира</param>
        public AddressRegister(int id, string street, string house, int flat)
        {
            this.id = id;
            this.street = street;
            this.house = house;
            this.flat = flat;
        }
    }
}
