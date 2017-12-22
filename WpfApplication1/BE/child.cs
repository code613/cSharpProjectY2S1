using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Child : person
    {//how is this
        private string mother_ID { get; }
        private bool isSpecial { get; set; }
        private string spicialty { get; set; }
        public override string ToString()
        {
            return "child:" + firstName + " " + lastName;
        }
        //ctor
        public Child(string id, string first_name, string last_name, DateTime Birthday, string Mother_ID) : base(id, first_name, last_name, Birthday)
        {
            mother_ID = Mother_ID;
        }
    }
}
