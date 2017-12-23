using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        private string contract_ID { get; set; }//8 digit??
        private string nanny_ID { get; }
        private string child_ID { get; }
        private bool meeting { get; set; }//what is this??
        private bool contractIsSighned { get; set; }
        private float paymentPerHour { get; set; }
        private float paymentPerMonth { get; set; }
        private string monthOrHourContract { get; set; }
        private DateTime starts { get; set; }
        private DateTime ends { get; set; }
        //other feilds as needed
        public override string ToString()
        {
            return " contract:" + contract_ID;
        }
        //ctor
        public Contract(string contractNumber, string Nanny_ID, string Child_ID)
        {
            contract_ID = contractNumber;
            nanny_ID = Nanny_ID;
            child_ID = Child_ID;
        }
    }
}
