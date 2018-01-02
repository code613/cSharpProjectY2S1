using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
       public string contract_ID { get; set; }//8 digit??
       public string nanny_ID { get; }
       public string mother_ID { get; }
       public string child_ID { get; }
       public bool meeting { get; set; }//what is this??
       public bool contractIsSighned { get; set; }
       public double paymentPerHour { get; set; }
       public double paymentPerMonth { get; set; }
       public string monthOrHourContract { get; set; }
       public DateTime starts { get; set; }
       public DateTime ends { get; set; }
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
