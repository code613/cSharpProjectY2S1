﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE   // create read update dealte   crud
{
    public class Mother : Person
    {
        public string housePhone { get; set; }
        public string cellPhone { get; set; }
        public string googleAddress { get; set; }
        public string searchArea { get; set; }//neiberhood?? is better?
        public bool[] daysNeedNanny = new bool[7];
        public DateTime[][] serviseNeededTimeTable = new DateTime[2][];
        //other feilds that will be needed
        private string comments { get; set; }//what is this??

        public override string ToString()
        {
            return "mother:" + firstName + " " + lastName + " " + cellPhone + " " + googleAddress;
        }
        //constructer
        public Mother(string id, string first_name, string last_name, DateTime Birthday) : base(id, first_name, last_name, Birthday)
        {

        }
    }
}
