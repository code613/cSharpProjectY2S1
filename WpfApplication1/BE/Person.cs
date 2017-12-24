using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        protected string ID { get; }
        public  string firstName { get; }
        public string lastName { get; }//for child made public
        public  DateTime Birthday { get; }
        public Person(string inID, string infirst_name, string inlast_name, DateTime inBirthday)
        {
            ID = inID; firstName = infirst_name; lastName = inlast_name; Birthday = inBirthday;
        }
    }
}