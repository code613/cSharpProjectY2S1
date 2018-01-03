﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BE
{
    public class Child : Person
    {
        public Mother myMother { get; } 
        public bool hasSpecialNeeds { get; set; }
        public string specificationOfNeeds { get; set; }
        public int monthsOld { get; set; }
        public override string ToString()
        {
            return "child:" + firstName + " " + lastName;
        }
        //ctor
        public Child(string id, string first_name,  DateTime Birthday, Mother mom,
            bool SpecialNeeds,string needs,int ageInMonth) : base(id, first_name, mom.lastName, Birthday)
        {
            myMother = mom;
            hasSpecialNeeds = SpecialNeeds;
            specificationOfNeeds = needs;
            monthsOld = ageInMonth;
       }
    }
}
