using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Mother : Person
    {
        public Mother()
        {
            daysNeedNanny = new DayOfWork[6];
            for (int i = 0; i < 6; i++)
            {
                daysNeedNanny[i] = new DayOfWork();
            }
            DaysNeedNanny = new bool[6];
        }
        public string housePhone { get; set; }
        public string cellPhone { get; set; }
        public string googleAddress { get; set; }
        public string searchArea { get; set; }
        public DayOfWork[] daysNeedNanny { get; set; }
        public bool[] DaysNeedNanny { get; set; }
        public bool isSingalParent { get; set; }
        public string comments { get; set; }
        public string needNannyAddress { get; set; }

        public override string ToString()
        {
            return "mother:" + firstName + " " + lastName + " " + cellPhone + " " + googleAddress;
        }
        public class DayOfWork
        {
            public int day;
            public TimeSpan start;
            public TimeSpan end;
            public DayOfWork() { start = new TimeSpan(); end = new TimeSpan(); }
        }
        ////constructer
        //public Mother(string id, string first_name, string last_name, DateTime Birthday) : base(id, first_name, last_name, Birthday)
        //{

        //}
    }
}
