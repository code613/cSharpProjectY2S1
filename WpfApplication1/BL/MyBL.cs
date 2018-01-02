using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;

namespace BL   //this layer it to chech that everything is in order so that it can be passed to the
    //DAL layer in order to reach the data center
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
        public List<Child> getListOfMothersChildren(Mother mo)
        {
            throw new NotImplementedException();
        }
        public List<Child> getListOfChildren()
        {
            throw new NotImplementedException();
        }
        public Child findChild(string ID)
        {
            List<Child> help = MyDal.getListOfChildren();

            foreach (var item in help)
            {
                if (item.ID == ID)
                    return item;
            }
            throw new ArgumentException("the child wasn't found");
        }
        private bool is3Month(Person per)
        {
            DateTime now = DateTime.Now;
            int age = now.Month - per.Birthday.Month;
            if (age > 3 || age == 3)
                return true;
            else 
                return false;
        }
        #endregion

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
        private static bool is18(Nanny nan)
        {    
            DateTime now = DateTime.Now;
            int age = now.Year - nan.Birthday.Year;
            if (age > 18 || age == 18)
                return true;
            else 
                return false;    
        }
        #endregion

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
            Child ch = findChild(con.child_ID);
            if (!is3Month(ch))
                throw new ArgumentException(" the child under the minimal age");
            con.paymentPerHour = nan.perHour;
            con.paymentPerMonth = salary(con);
            if (isFull(con, nan))
                throw new ArgumentException("this nanny is full and she can't take more children");
            MyDal.addContract(con);
        }

        private bool isFull(Contract con, Nanny nan)
        {
            int sum = 0;
            foreach (var item in getListOfContracts())
            {
                if (item.nanny_ID == con.nanny_ID)
                {
                    sum++;
                }
            }
            if (sum == nan.max_kids)
                return true;
            return false;
                
        }

        public void deleteContract(Contract con)
        {
            throw new NotImplementedException();
        }
        public List<Contract> getListOfContracts()
        {
            throw new NotImplementedException();
        }
        public void updateContractDetalis(Contract con)
        {
            throw new NotImplementedException();
        }
        #endregion
        public double salary(Contract con)
        {
            Nanny nan = findNanny(con.nanny_ID);
            Mother mo = findMother(con.mother_ID);
            double nannySalary = 0;
            if (con.monthOrHourContract == "perMonth")
            {
                nannySalary = con.paymentPerMonth;
            }
            else //if (con.monthOrHourContract=="perHour")
            {
                double hours = 0;
                for (int i = 0; i < 6; i++)
                {
                    TimeSpan diff = mo.serviseNeededTimeTable[i][1] - mo.serviseNeededTimeTable[i][0];
                    hours += diff.TotalHours;
                }
                nannySalary = (double)4 * hours * nan.perHour;
            }
            List<Child> childrenList = getListOfMothersChildren(mo);
            List<Contract> contractList = getListOfContracts();
            //
            foreach (var contract in contractList)
            {
                if (contract.nanny_ID == nan.ID)
                {
                    foreach (var child in childrenList)
                    {
                        if (contract.child_ID == child.ID)
                        {
                            nannySalary *= 0.98;
                        }
                    }
                }
            }
            return nannySalary;
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
        public List<Nanny> matchingNannies(Mother mo)
        {
            List<Nanny> matchingNannies = new List<Nanny>();
            bool isEmpty = true;
            foreach (var item in getListOfNannies())
            {
                bool isMatch = true;
                for (int i = 0; i < 6; i++)
                {
                    if (mo.serviseNeededTimeTable[i][0]<item.TimeTable[i][0] || mo.serviseNeededTimeTable[i][1] > item.TimeTable[i][1])
                    {
                        isMatch = false;
                    }
                }
                if(isMatch)
                {
                    matchingNannies.Add(item);
                    isEmpty = false;
                }
            }
            if(isEmpty)
                Console.WriteLine("didn't found matching nannies,here is the 5 closest:");
            matchingNannies = closestToMotherNeeds( mo);
            return matchingNannies;
        }
        private List<Nanny> closestToMotherNeeds(Mother mo)
        {
            
        }

        public List<Child> childrenWithoutNanny()
        {
            List<Child> children_without_nanny = new List<Child>();
            foreach (var ch in getListOfChildren())
            {
                bool asNanny = false;
                foreach (var con in getListOfContracts())
                {
                    if (ch.ID==con.child_ID)
                    {
                        asNanny = true;
                        break;
                    }
                }
                if (!asNanny)
                    children_without_nanny.Add(ch);
            }
            return children_without_nanny;
        }
        public List<Nanny> vocationAcordingToGov()
        {
            List<Nanny> vocation_acording_to_gov = new List<Nanny>();
            foreach (var item in getListOfNannies())
            {
                if (item.GovVacation)
                    vocation_acording_to_gov.Add(item);
            }
            return vocation_acording_to_gov;
        }
       
        public IEnumerable<Contract> contractFeetToCondition(Func<Contract ,bool> someDel)
        {
            return from  con in getListOfContracts()
                   where someDel(con)
                   select con;
        }
        public IEnumerable<string> FeetToCondition(Func<Contract, bool> someDel)
        {
            return from con in getListOfContracts()
                   where someDel(con)
                   select con.contract_ID;
        }

        public IEnumerable<IGrouping<int, Nanny>> perAge(bool maxAge=false)
        {
            IEnumerable<IGrouping<int, Nanny>> query = from nan in getListOfNannies()
                                                       group nan by nan.MaxMonthAge / 3;                      
            return query;
            
        }

        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
    }
}
