using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person//id ,first name,last name,birthday
    {
        public Nanny()
        {
            ImgPath = @"./ resources / badCaretakerIMG.jpg";
            Birthday = DateTime.Now.AddYears(-30);
            TimeTable = new DayOfWork[6];
            for (int i = 0; i < 6; i++)
            {
                TimeTable[i] = new DayOfWork();
            }
            WorkWeek = new bool[6];
        }
        public string phone { get; set; }
        public string Address { get; set; }
        public bool elevator { get; set; }
        public int floor { get; set; }
        
        public int Expirence { get; set; }
        public int MaxChildren { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool isPerHour { get; set; }
        public float HourSalary { get; set; }
        public float monthSalary { get; set; }
        public bool[] WorkWeek { get; set; }
        public DayOfWork[] TimeTable { get; set; }
        public bool GovVacation { get; set; }
        public string Recommendations { get; set; }
        public override string ToString()
        {
            return "nanny: " + firstName + " " + lastName + " " + phone + " " + Address;
        }

        
    }
}



