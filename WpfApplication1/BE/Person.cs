using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public string ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime Birthday { get; set; }
        //ctor
        public Person() { }
        //public Person(string inID, string infirst_name, string inlast_name, DateTime inBirthday)
        //{
        //    ID = inID; firstName = infirst_name; lastName = inlast_name; Birthday = inBirthday;
        //}
    }
}