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

namespace BL

{
    public class MyBL : IBL
    {
        //Idal MyDal;
        #region Singleton
        private static readonly MyBL instance = new MyBL();

        public static MyBL Instance
        {
            get { return instance; }
        }
        #endregion

        //public MyBL()
        //{
        Idal MyDal = DALFactory.FactoryDAL.GetDAL();
            //init();
        //}
        #region child
        public void addChild(Child ch)
        {
            try
            {
                MyDal.addChild(ch);

            }
            catch (InvalidCastException e)
            {

                throw e;
            }

        }
        public void deleteChild(string id)
        {
            MyDal.deleteChild(id);
        }
        public void updateChildDetalis(Child ch)
        {
            MyDal.updateChildDetalis(ch);
        }
        public List<Child> getListOfMothersChildren(Mother mo)
        {
            return MyDal.getListOfMothersChildren(mo);
        }
        public List<Child> getListOfChildren(Func<Child, bool> predicate = null)
        {
            try
            {
                return MyDal.getListOfChildren(predicate);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public Child findChild(string ID)
        {
            return MyDal.findChild(ID);
        }
        private bool is3Month(Child ch)
        {
            DateTime now = DateTime.Now;
            int age = now.Month - ch.Birthday.Month;
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
                throw new Exception("the nanny under minimal age");
            MyDal.addNanny(nan);
        }
        public void deleteNanny(string id)
        {
            MyDal.deleteNanny(id);
        }
        public List<Nanny> getListOfNannies(Func<Nanny, bool> predicate = null)
        {
            try
            {
                return MyDal.getListOfNannies(predicate);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void updateNannyDetalis(Nanny nan)
        {
            MyDal.updateNannyDetalis(nan);
        }
        public Nanny findNanny(string ID)
        {
            return MyDal.findNanny(ID);
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
            MyDal.addMother(mom);
        }
        public void deleteMother(string id)
        {
            MyDal.deleteMother(id);
        }
        public void updateMotherDetalis(Mother mom)
        {
            MyDal.updateMotherDetalis(mom);
        }
        public List<Mother> getListOfMothers(Func<Mother, bool> predicate = null)
        {
            try
            {
                return MyDal.getListOfMothers(predicate);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public Mother findMother(string ID)
        {
            return MyDal.findMother(ID);
        }
        #endregion

        #region contract
        public void addContract(Contract con)
        {
            Nanny nan = findNanny(con.nanny_ID);
            Child ch = findChild(con.child_ID);
            if (!is3Month(ch))
                throw new Exception(" the child under the minimal age");
            if (isFull(con, nan))
                throw new Exception("this nanny is full and she can't take more children");
            int childAge = DateTime.Now.Month - ch.Birthday.Month;
            if (childAge > nan.MaxAge || childAge < nan.MinAge)
                throw new Exception("this nanny dosn't take kids at this age");
            con.paymentPerHour = nan.HourSalary;
            con.paymentPerMonth = salary(con);

            MyDal.addContract(con);
        }

        public bool isFull(Contract con, Nanny nan)
        {
            int sum = 0;
            foreach (var item in getListOfContracts())
            {
                if (item.nanny_ID == con.nanny_ID)
                {
                    sum++;
                }
            }
            if (sum == nan.MaxChildren)
                return true;
            return false;

        }

        public void deleteContract(int number)
        {
            MyDal.deleteContract(number);
        }
        public List<Contract> getListOfContracts(Func<Contract, bool> predicate = null)
        {
            try
            {
                return MyDal.getListOfContracts(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void updateContractDetalis(Contract con)
        {
            MyDal.updateContractDetalis(con);
        }
        public Contract findContract(int number)
        {
            return MyDal.findContract(number);
        }

        #endregion

        #region functions
        /// <summary>
        /// calculate the sallary of nanny in contract
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
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
                    TimeSpan diff = mo.serviseNeededTimeTable[i].end - mo.serviseNeededTimeTable[i].start;
                    hours += diff.TotalHours;
                }
                nannySalary = (double)4 * hours * nan.HourSalary;
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

        /// <summary>
        /// return list of nannies that matching to mother needs
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public List<Nanny> matchingNannies(Mother mo, Child ch)
        {
            List<Nanny> matchingNannies = new List<Nanny>();
            foreach (var item in getListOfNannies())
            {
                bool isMatch = true;
                for (int i = 0; i < 6; i++)//check if the days are matching
                {
                    if (mo.daysNeedNanny[i] && !item.WorkWeek[i])
                        isMatch = false;
                }
                for (int i = 0; i < 6; i++)//check if the hours are matching
                {
                    if (mo.serviseNeededTimeTable[i].start < item.TimeTable[i].start || mo.serviseNeededTimeTable[i].start > item.TimeTable[i].start)
                        isMatch = false;
                }
                int childAge = DateTime.Now.Month - ch.Birthday.Month;
                if (childAge > item.MaxAge || childAge < item.MinAge)//check if the nanny get child in that age
                    isMatch = false;
                if (isMatch)
                {
                    matchingNannies.Add(item);
                }
            }
            if (matchingNannies.Count == 0)
            {
                throw new Exception("didn't find nanny match to mother needs");
            }
            return matchingNannies;
        }

        /*public List<Nanny> closestToMotherNeeds(Mother mo)
        {

        }*/

        /// <summary>
        /// return's all nannies that are close to mother required location(15 km)
        /// </summary>
        /// <param name="mom"></param>
        /// <returns></returns>
        public IEnumerable<Nanny> proximityNannies(Mother mom)
        {
            return from Nanny n in getListOfNannies()
                   where CalculateDistance(myEnum.TipeOfTravel.walking, n.Address, (mom.searchArea == "" ? mom.address : mom.searchArea)) <= 15000
                   select n;
        }

        /// <summary>
        /// return's all kids that left without nanny
        /// </summary>
        /// <returns></returns>
        public List<Child> childrenWithoutNanny()
        {
            List<Child> children_without_nanny = new List<Child>();
            foreach (var ch in getListOfChildren())
            {
                bool asNanny = false;
                foreach (var con in getListOfContracts())
                {
                    if (ch.ID == con.child_ID)
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

        /// <summary>
        /// check's if the nanny vocation is suited to govrement
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// return's all the contracts that are feet to some condition
        /// </summary>
        /// <param name="someDel"></param>
        /// <returns></returns>
        public IEnumerable<Contract> contractFeetToCondition(Func<Contract, bool> someDel)
        {
            return from con in getListOfContracts()
                   where someDel(con)
                   select con;
        }

        /// <summary>
        /// return's the con_number of the contracts that are feet to some condition
        /// </summary>
        /// <param name="someDel"></param>
        /// <returns></returns>
        public IEnumerable<int> conFeetToCondition(Func<Contract, bool> someDel)
        {
            return from Contract con in getListOfContracts()
                   where someDel(con)
                   select con.contract_number;
        }

        /// <summary>
        /// return's the nannies acording to nax/min age of children
        /// </summary>
        /// <param name="maxAge"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Nanny>> perAge(bool maxAge = false)
        {
            if (maxAge)
            {
                IEnumerable<IGrouping<int, Nanny>> query = from nan in getListOfNannies()
                                                           group nan by nan.MaxAge / 3;
                return query;
            }
            else
            {
                IEnumerable<IGrouping<int, Nanny>> query = from nan in getListOfNannies()
                                                           group nan by nan.MinAge / 3;
                return query;
            }



        }

        /// <summary>
        /// return groups of nannies acording to their distance
        /// </summary>
        /// <param name="mo"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Nanny>> Distance(Mother mo, myEnum.TipeOfTravel tipeOfTravel)
        {

            IEnumerable<IGrouping<int, Nanny>> query = from nan in getListOfNannies()
                                                       group nan by CalculateDistance(tipeOfTravel, mo.searchArea, nan.Address) / 5;
            return query;

        }

        /// <summary>
        /// calculate distance from source to destenation using google maps
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        /// 
        public static int CalculateDistance(myEnum.TipeOfTravel tipeOfTravel, string source, string dest)
        {

            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = tipeOfTravel == myEnum.TipeOfTravel.walking ? TravelMode.Walking : TravelMode.Driving,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        #endregion
        
    }
}
