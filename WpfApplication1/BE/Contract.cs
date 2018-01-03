using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
       public string contract_number { get; set; }
       public string nanny_ID { get; set; }
       public string mother_ID { get; set; }
       public string child_ID { get; set; }
       public bool meeting { get; set; }
       public bool Sighned { get; set; }
       public double paymentPerHour { get; set; }
       public double paymentPerMonth { get; set; }
       public string monthOrHourContract { get; set; }
       public DateTime starts { get; set; }
       public DateTime ends { get; set; }
        //other feilds as needed
        public override string ToString()
        {
            return " contract:" + contract_number;
        }
        //ctor
        public Contract(string contractNumber, string Nanny_ID, string Child_ID ,string mother_id
            ,bool haveTheyMet,bool is_Sighnd)
        {
            contract_number = contractNumber;
            nanny_ID = Nanny_ID;
            child_ID = Child_ID;
            mother_ID=
            Sighned=is_Sighned;
            meeting= haveTheyMet
        }
    }
}
