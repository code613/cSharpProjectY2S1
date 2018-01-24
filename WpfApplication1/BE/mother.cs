using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Mother : Person//person :id, first name,last name,birthday.
    {
        public Mother()
        {
            ImgPath = @"./ resources / badCaretakerIMG.jpg";
            Birthday = DateTime.Now.AddYears(-30);
            serviseNeededTimeTable= new DayOfWork[6];
            ID = "33";
            for (int i = 0; i < 6; i++)
            {
                serviseNeededTimeTable[i]= new DayOfWork();
            }
            daysNeedNanny = new bool[6];
        }
        public string housePhone { get; set; }
        public string cellPhone { get; set; }
        public string address { get; set; }
        public string searchArea { get; set; }
        public bool[] daysNeedNanny { get; set; }
        public DayOfWork[] serviseNeededTimeTable { get; set; }
        public bool isSingalParent { get; set; }
        public string comments { get; set; }
               

        public override string ToString()
        {
            return "mother:" + firstName + " " + lastName + " " + cellPhone + " " + address;
        }
        

    }
    public class DayOfWork
    {
        public int day;
        public TimeSpan start;
        public TimeSpan end;
        public DayOfWork() { start = new TimeSpan(); end = new TimeSpan(); }
    }

}
