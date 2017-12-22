using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Contract
    {
        private string contract_number { get; set; }
        private string nanny_ID { get; }
        private string child_ID { get; }
        private bool meeting { get; set; }
        private bool isSighned { get; set; }
        private float monthPerHour { get; set; }
        private float monthSelery { get; set; }
        private DateTime starts { get; set; }
        private DateTime ends { get; set; }
        public override string ToString()
        {
            return " contract:" + contract_number;
        }
        //ctor
        public Contract(string contractNumber, string Nanny_ID, string Child_ID)
        {
            contract_number = contractNumber;
            nanny_ID = Nanny_ID;
            child_ID = Child_ID;
        }
    }
}
