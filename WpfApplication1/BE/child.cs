using System;
using System.Collections.Generic;
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
        //ctor
        //public Child(string id, string first_name, DateTime Birthday, Mother mom,
        //    bool SpecialNeeds, string needs) : base(id, first_name, mom.lastName, Birthday)
        //{
        //    myMother = mom;
        //    hasSpecialNeeds = SpecialNeeds;
        //    specificationOfNeeds = needs;

        //}
    }
}
