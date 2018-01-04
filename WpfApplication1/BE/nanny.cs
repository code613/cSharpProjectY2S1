using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person
    {

        public string phone { get; set; }
        public string Address { get; set; }
        public bool elevator { get; set; }
        public int floor { get; set; }
        public int Expirence { get; set; }
        public int MaxChildren { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool isPerHour { get; set; }
        public float HourSallary { get; set; }
        public float SallaryPerMonths { get; set; }
        public bool[] WorkWeek = new bool[7];
        public DateTime[][] TimeTable = new DateTime[2][];
        public bool GovVacation { get; set; }
        public string Recommendations { get; set; }
        public override string ToString()
        {
            return "nanny: " + firstName + " " + lastName + " " + phone + " " + Address;
        }

        //ctor
        public Nanny() { }
        public Nanny(string id, string first_name, string last_name
            , DateTime birthday, string inphone, string Addr
            , bool is_elevator, int infloor, int inexperience, int inmax_kids
            , int inMinAge, int inMaxAge, bool per_hour, bool inGovVacation, string inReferences) : base(id, first_name, last_name, birthday)
        {
            phone = inphone;
            Address = Addr;
            elevator = is_elevator;
            floor = infloor;
            Expirence = inexperience;
            MaxChildren = inmax_kids;
            MinAge = inMinAge;
            MaxAge = inMaxAge;
            isPerHour = per_hour;
            bool[] WorkWeek = new bool[7];
            DateTime[][] TimeTable = new DateTime[2][];
            GovVacation = inGovVacation;
            Recommendations = inReferences;
        }
    }
}



