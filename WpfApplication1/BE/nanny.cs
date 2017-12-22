using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class nanny : person
    {
        //private string ID { get; }
        //private string first_name { get; }
        //private string last_name { get; }
        //private DateTime Birthday { get; }
        private string phone { get; set; }//5
        private string googleAddress { get; set; }
        private bool is_elevator { get; set; }
        private int floor { get; set; }
        private int experience { get; set; }
        private int max_kids { get; set; }//10
        private int MinAge { get; }
        private int MaxAge { get; }
        private bool HourRateTorF { get; }
        public bool[] WorkWeek = new bool[7];//like this??
        public DateTime[][] TimeTable = new DateTime[2][];//i don't know if this works
        private bool GovVacation { get; set; }
        private string Refrinces { get; }
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
        public nanny(string id, string first_name, string last_name, DateTime Birthday) : base(id, first_name, last_name, Birthday)
        {
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
        }
    }
}
