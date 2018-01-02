using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;

namespace BL
{
    class MyBL : IBL
    {
        #region Singleton
        private static readonly MyBL instance = new MyBL();

        public static MyBL Instance
        {
            get { return instance; }
        }
        #endregion

        static Idal MyDal;


        #region child
        public void addChild(Child ch)
        {
            MyDal.addChild(ch);
        }
        public void deleteChild(Child ch)
        {
            
        }
        public void updateChildDetalis(Child ch)
        {
            throw new NotImplementedException();
        }
        public List<Child> getListOfChildrenMother(Mother mo)
        {
            throw new NotImplementedException();
        }
        #endregion
        private bool is3Month(Person per)
        {
            if (DateTime.Today.Month > per.Birthday.Month)
                return true;
            else if (DateTime.Today.Month < per.Birthday.Month)
                return false;
            else //if (DateTime.Today.Month == nan.Birthday.Month)
            {
                if (DateTime.Today.Day < per.Birthday.Day)
                    return false;
                else
                    return true;
            }
        }

        #region Nanny
        public void addNanny(Nanny nan)
        {
            if (!is18(nan))
                throw new ArgumentException("the nanny under minimal age");
            MyDal.addNanny(nan);
        }
        public void deleteNanny(Nanny nan)
        {
            List<Nanny> nannyList = getListOfNannies();
            foreach (var item in nannyList)
            {
                if (nan == item)
                    nannyList.Remove(item);
                break;
            }
        }
        public List<Nanny> getListOfNannies()
        {
            return MyDal.getListOfNannies();
        }
        public void updateNannyDetalis(Nanny nan,string last_name)
        {
            List<Nanny> nannyList = getListOfNannies();
            var nanny = nannyList.Where(n => n.ID == nan.ID).FirstOrDefault();
            if (nanny != null)
            {
                nanny.lastName = last_name;
            }
        }
        public Nanny findNanny(string ID)
        {
            List<Nanny> help = MyDal.getListOfNannies();

            foreach (var item in help)
            {
                if (item.ID == ID)
                    return item;
            }
            throw new ArgumentException("the nanny was not found");
        }
        #endregion
        private static bool is18(Nanny nan)
        {
            
            int age = DateTime.Today.Year - nan.Birthday.Year;
            if (age > 18)
                return true;
            else if (age < 18)
                return false;
            else //if (age == 18)
            {
                if (DateTime.Today.Month > nan.Birthday.Month)
                    return true;
                else if (DateTime.Today.Month < nan.Birthday.Month)
                    return false;
                else //if (DateTime.Today.Month == nan.Birthday.Month)
                {
                    if (DateTime.Today.Day < nan.Birthday.Day)
                        return false;
                    else
                        return true;
                }
            }
        }

        #region mother
        public void addMother(Mother mom)
        {
            throw new NotImplementedException();
        }
        public void deleteMother(Mother mom)
        {
            throw new NotImplementedException();
        }
        public void updateMotherDetalis(Mother mom)
        {
            throw new NotImplementedException();
        }
        public List<int> getListOfMothers()
        {
            throw new NotImplementedException();
        }
        public Mother findMother(string ID)
        {
            List<Mother> help = MyDal.getListOfMothers();
            
            foreach (var item in help)
            {
                if (item.ID == ID)
                    return item;
            }
            throw new ArgumentException("the mother wasnt found");
        }
        #endregion

        #region contract
        public void addContract(Contract con)
        {
            Nanny nan = findNanny(con.nanny_ID);
            Person per= find(con.child_ID);
            if (!is3Month(per))
                throw new ArgumentException(" the child under the minimal age");
            con.paymentPerHour = nan.perHour;
            con.paymentPerMonth = salary(con);
            MyDal.addContract(con);
        }
        public void deleteContract(Contract con)
        {
            throw new NotImplementedException();
        }
        public List<int> getListOfContracts()
        {
            throw new NotImplementedException();
        }
        public void updateContractDetalis(Contract con)
        {
            throw new NotImplementedException();
        }
        #endregion
                
        public double salary (Contract con)
        {
            Nanny nan = findNanny(con.nanny_ID);
            Mother mo = findMother(con.mother_ID);
            double nannySalary = 0;
            if (con.monthOrHourContract=="perMonth")
            {
                nannySalary =con.paymentPerMonth;
            }
            else //if (con.monthOrHourContract=="perHour")
            {
                double hours = 0;
                for (int i = 0; i < 6; i++)
                {
                    TimeSpan diff = mo.serviseNeededTimeTable[i][1] - mo.serviseNeededTimeTable[i][0];
                    hours +=  diff.TotalHours;
                }
                nannySalary=(double)4 * hours * nan.perHour;
            }

        }
        public Person find(string ID)
        {
            List<Mother> help =MyDal.getListOfMothers();
            List<Child> help1 =MyDal.getListOfChildren();
            List<Nanny> help2 =MyDal. getListOfNannies();
            foreach (var item in help)
            {
                if (item.ID == ID)
                    return item;
            }
            foreach (var item in help1)
            {
                if (item.ID == ID)
                    return item;
            }
            foreach (var item in help2)
            {
                if (item.ID == ID)
                    return item;
            }
            throw new ArgumentException("the person wasnt found");
        }


       



        


        




    }
}
