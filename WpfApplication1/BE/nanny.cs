using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person
    {

        public  string phone { get;  set; }
        public  string googleAddress { get; set; }
        public  bool is_elevator { get; set; }
        public  int floor { get; set; }
        public  int yearsOfExperience { get; set; }
        public  int max_kids { get; set; }
        public  int MinMonthAge { get; }
        public  int MaxMonthAge { get; }
        public  bool isPerHout { get; }
        public float perHour { get; set; }
        public float perMonth { get; set; }
        public bool[] WorkWeek = new bool[7];
        public DateTime[][] TimeTable = new DateTime[2][];
        public  bool GovVacation { get; set; }
        public  string Refrinces { get; }
//other functions as needed
        public override string ToString()
        {
            return "nanny: " + firstName + " " + lastName + " " + phone + " " + googleAddress;
        }
        //public nanny(string inID, string infirst_name, string inlast_name  //first 3
        //    , DateTime inbirthday, string inphone, string ingoogleAddr       // 6
        //    , bool inis_elevator, int infloor, int inexperience, int inmax_kids  //10
        //    , int inMinAge, int inMaxAge, bool inHourRateTorF, bool inGovVacation, string inRefrinces)
        //    person()
        //{
        //}
        public Nanny(string id, string first_name, string last_name, DateTime Birthday) : base(id, first_name, last_name, Birthday)
        {
        }
    }
}
            //string phone;
            //string googleAddress;
            //bool is_elevator;
            //int floor;
            //int experience;
            //int max_kids;
            //int MinAge;
            //int MaxAge;
            //bool HourRateTorF;
            //bool[] WorkWeek = new bool[7];//like this??
            //DateTime[][] TimeTable = new DateTime[2][];
            //bool GovVacation; 
            //string Refrinces;


            //Console.WriteLine("now enter your phone number press enter and then google address");
            //phone = Console.Read();
