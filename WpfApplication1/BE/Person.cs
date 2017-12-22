using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class person
    {
        protected string ID { get; }
        protected string firstName { get; }
        protected string lastName { get; }
        protected DateTime Birthday { get; }
        public person(string inID, string infirst_name, string inlast_name, DateTime inBirthday)
        {
            ID = inID; firstName = infirst_name; lastName = inlast_name; Birthday = inBirthday;
        }
    }
}