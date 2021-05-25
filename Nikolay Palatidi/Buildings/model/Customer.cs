using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.model
{
    public class Customer
    {
        public int contractid { get; set; }
        public string name { get; set; }
        public string workingHours { get; set; }
        public string typeOfPayment { get; set; }
        public int paymentAmount { get; set; }

        public Customer(int contractid, string name, string workingHours, string typeOfPayment, int paymentAmount)
        {
            this.contractid = contractid;
            this.name = name;
            this.workingHours = workingHours;
            this.typeOfPayment = typeOfPayment;
            this.paymentAmount = paymentAmount;
        }

        public Customer(string name, string workingHours, string typeOfPayment, int paymentAmount)
        {
            this.name = name;
            this.workingHours = workingHours;
            this.typeOfPayment = typeOfPayment;
            this.paymentAmount = paymentAmount;
        }
    }
}
