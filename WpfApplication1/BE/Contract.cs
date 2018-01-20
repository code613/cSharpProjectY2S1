using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public Contract()
        {
            starts = new DateTime();
            starts = DateTime.Now;
            ends = new DateTime();
            ends = DateTime.Now.AddMonths(3);
        }
        public int contract_number { get; set; }
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
        public override string ToString()
        {
            return " contract:" + contract_number;
        }
        
    }
}