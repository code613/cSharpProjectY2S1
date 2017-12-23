using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Child : Person///why is the class defalted to private ????????????
    {
        private Mother myMother { get; } //a feild that says who the mother is
        private bool hasSpecialNeeds { get; set; }
        private string specificationOfNeeds { get; set; }
        private int monthsOld { get; set; }
        public override string ToString()
        {
            return "child:" + firstName + " " + lastName;
        }
        //ctor
        public Child(string id, string first_name,  DateTime Birthday, Mother theMother) : base(id, first_name, theMother.lastName, Birthday)
        {
            myMother = theMother;
        }
    }
}
