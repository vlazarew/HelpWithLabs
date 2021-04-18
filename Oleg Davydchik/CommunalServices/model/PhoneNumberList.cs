/*using CommunalServices.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalServices.model
{
    class PhoneNumberList
    {
        public int consumerid { get; set; }
        public int phoneNumberId { get; set; }

        public PhoneNumberList(List<string> numbers)
        {
            foreach (string number in numbers)
            {
                PhoneNumber phone = new PhoneNumber(number);
                if (PhoneDAO.saveNumber(phone))
                {
                    phone = PhoneDAO.getPhoneByNumber(number);
                    //this.phoneNumbersId.Add(phone.id);
                }
                else
                {
                    throw new Exception("Ошибка сохранения телефона");
                }

            }
        }

    }
}*/
