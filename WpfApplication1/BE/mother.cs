using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE   // create read update dealte   crud
{
    class Mother : person
    {
        private string phone { get; set; }
        private string googleAddress { get; set; }
        private string searchArea { get; set; }
        public bool[] needNanny = new bool[7];
        public DateTime[][] TimeTable = new DateTime[2][];
        private string comandes { get; set; }

        public override string ToString()
        {
            return "mother:" + firstName + " " + lastName + " " + phone + " " + googleAddress;
        }
        //constructer
        public Mother(string id, string first_name, string last_name, DateTime Birthday) : base(id, first_name, last_name, Birthday)
        {

        }
    }
}
