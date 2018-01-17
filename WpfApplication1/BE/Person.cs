using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public Person()
        {
            Birthday = new DateTime();
        }
        public string ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime Birthday { get; set; }
        
    }
}