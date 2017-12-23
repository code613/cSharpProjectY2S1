using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person
    {
        private string phone { get; set; }
        private string googleAddress { get; set; }
        private bool is_elevator { get; set; }
        private int floor { get; set; }
        private int yearsOfExperience { get; set; }
        private int max_kids { get; set; }
        private int MinMonthAge { get; }
        private int MaxMonthAge { get; }
        private bool HourRateTorF { get; }//what is this??
        public bool[] WorkWeek = new bool[7];//like this?? think so!
        public DateTime[][] TimeTable = new DateTime[2][];//i don't know if this works
        private bool GovVacation { get; set; }
        private string Refrinces { get; }
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
