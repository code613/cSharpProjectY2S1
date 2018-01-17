using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Child : Person 
    {
        public string MotherID { get; set; }
        public bool hasSpecialNeeds { get; set; }
        public string specificationOfNeeds { get; set; }

        public override string ToString()
        {
            return "child:" + firstName + " " + lastName;
        }
        public Child() { }
        
    }
}
