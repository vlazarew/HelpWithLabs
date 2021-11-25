using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    /// <summary>
    /// Учетные данные
    /// </summary>
    class Credentials
    {
        // id учетных данных
        [BsonId]
        public int id { get; set; }
        // логин
        [BsonElement("login")]
        public string login { get; set; }
        // пароль
        [BsonElement("password")]
        public string password { get; set; }

        /// <summary>
        /// Конструктор без id
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        public Credentials(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        /// <summary>
        /// Конструктор c id
        /// </summary>
        /// <param name="id">id учетных данных</param>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        public Credentials(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }

    }
}
