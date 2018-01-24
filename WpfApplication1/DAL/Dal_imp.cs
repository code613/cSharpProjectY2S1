using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;

namespace DAL
{

    public class Dal_imp1 : Idal
    {
        #region Singleton
        private static readonly Dal_imp1 instance = new Dal_imp1();

        public static Dal_imp1 Instance
        {
            get { return instance; }
        }
        #endregion
        private Dal_imp1()
        {
         init();
        }
        protected static Dal_imp1 dal;
        public int flag { get {return flag; } set { flag = 0; } }
        public static Dal_imp1 Dal
        {
            get
            {
                if (dal == null)
                    dal = new Dal_imp1();
                return dal;
            }
        }
        static Random r = new Random();

        #region child
        public void addChild(Child child)
        {
            Child ch = findChild(child.ID);
            //if (ch != null)
            //    throw new Exception("child with the same id already exists...");
            DS.DataSourse.listOfChildren.Add(child);
        }
        public void deleteChild(string id)
        {
            Child ch = findChild(id);
            if (ch == null)
                throw new Exception("child  not found...");
            DS.DataSourse.listOfChildren.Remove(ch);
        }
        public void updateChildDetalis(Child child)
        {
            int index = DS.DataSourse.listOfChildren.FindIndex(c => c.ID == child.ID);
            if (index == -1)
                throw new Exception("child not found...");
            DS.DataSourse.listOfChildren[index] = child;
        }
        public Child findChild(string ID)
        {
            return DataSourse.listOfChildren.FirstOrDefault(c => c.ID == ID);
            
        }
        public List<Child> getListOfChildren(Func<Child,bool> predicate=null)
        {
            if (predicate != null)
                return DataSourse.listOfChildren.Where(predicate).ToList();
            return DataSourse.listOfChildren;
        }
        #endregion

        #region nanny
        public void addNanny(Nanny nanny)
        {
            Nanny nan = findNanny(nanny.ID);
            if (nan != null)
                throw new Exception("nanny with the same id already exsist...");

            DS.DataSourse.listOfNannys.Add(nanny);
        }
        public void deleteNanny(string id)
        {
            Nanny nan = findNanny(id);
            if (nan == null)
                throw new Exception("nanny not found...");
            DS.DataSourse.listOfNannys.Remove(nan);
        }
        public void updateNannyDetalis(Nanny nan)
        {
            int index = DS.DataSourse.listOfNannys.FindIndex(n => n.ID == nan.ID);
            if (index == -1)
                throw new Exception("nanny not found...");
            DS.DataSourse.listOfNannys[index] = nan;
        }
        public Nanny findNanny(string ID)
        {
            return DS.DataSourse.listOfNannys.FirstOrDefault(n => n.ID == ID);
        }
        public List<Nanny> getListOfNannies(Func<Nanny,bool> predicate=null)
        {
            if (predicate != null)
                return DataSourse.listOfNannys.Where(predicate).ToList();
            return DS.DataSourse.listOfNannys;
        }
        #endregion

        #region mother
        public void addMother(Mother mother)
        {
            Mother mom = findMother(mother.ID);
            if (mom != null)
                throw new Exception("mother with the same id already exsist...");
            DS.DataSourse.listOfMothers.Add(mother);
        }
        public void deleteMother(string id)
        {
            Mother mom = findMother(id);
            //if (mom == null)
            //    throw new Exception("mother  not found...");
            DS.DataSourse.listOfMothers.Remove(mom);
        }
        public void updateMotherDetalis(Mother mom)
        {
            int index = DS.DataSourse.listOfMothers.FindIndex(m => m.ID == mom.ID);
            if (index == -1)
                throw new Exception("mother not found...");
            DS.DataSourse.listOfMothers[index] = mom;
        }
        public Mother findMother(string ID)
        {
            return DS.DataSourse.listOfMothers.FirstOrDefault(m => m.ID == ID);
        }
        public List<Mother> getListOfMothers(Func<Mother,bool> predicate=null)
        {
            if (predicate != null)
                return DataSourse.listOfMothers.Where(predicate).ToList(); 
            return DS.DataSourse.listOfMothers;
        }
        public List<Child> getListOfMothersChildren(Mother mom)
        {
            List<Child> myKidsList = new List<Child>();
            myKidsList.FindAll(C => findMother(C.MotherID) == mom);
            if (myKidsList.Count == 0)
                throw new Exception("this mother as No kids in the sistem");
            return myKidsList;


        }
        #endregion

        #region contract
        public void addContract(Contract contract)
        {
            int number = r.Next(100000000, 399999999);
            while (findContract(number) != null)
            {
                number = r.Next(100000000, 399999999);
            }
            contract.contract_number = number;

            Mother mom = findMother(contract.mother_ID);
            Nanny nan = findNanny(contract.nanny_ID);
            if (nan == null || mom == null)
                throw new Exception("error in nanny or mother id...");
            
            DS.DataSourse.listOfConntracts.Add(contract);
        }
        public void deleteContract(int number)
        {
            Contract con = findContract(number);
            if (con == null)
                throw new Exception("contract  not found...");
            DS.DataSourse.listOfConntracts.Remove(con);
        }
        public void updateContractDetalis(Contract con)
        {
            int index = DS.DataSourse.listOfConntracts.FindIndex(c => c.contract_number == con.contract_number);
            if (index == -1)
                throw new Exception("contract not found...");
            DS.DataSourse.listOfConntracts[index] = con;
        }
        public Contract findContract(int contract_number)
        {
            return DS.DataSourse.listOfConntracts.FirstOrDefault(c => c.contract_number == contract_number);
        }
        public List<Contract> getListOfContracts(Func<Contract,bool> predicate=null)
        {
            if (predicate != null)
                return DataSourse.listOfConntracts.Where(predicate).ToList();
            return DS.DataSourse.listOfConntracts;
        }
        #endregion
        void init()  //took from MyBL
        {

            addNanny(new Nanny
            {
                ID = "123",
                firstName = "shifi",
                lastName = "levy",
              //  Birthday = DateTime.Parse("31.12.88"),
                Address = "HaRav Shalom Shabazi St 12, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                phone = "0529344513",
                MaxAge = 15,
                MinAge = 3,
                MaxChildren = 8,
                isPerHour = false,
                monthSalary = 900,
                GovVacation = false,
                WorkWeek = new bool[] { true, true, true, true, true, true, false },
                //TimeTable = new DayOfWork[]
                //      {
                //    new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 0, 0) },
                //    new DayOfWork { day = 1, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 0, 0) },
                //    new DayOfWork { day = 2, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 0, 0) },
                //    new DayOfWork { day = 3, end = new TimeSpan(17, 0, 0), start = new TimeSpan(9, 0, 0) },
                //    new DayOfWork { day = 4, end = new TimeSpan(17, 0, 0), start = new TimeSpan(9, 0, 0) },
                //    new DayOfWork { day = 5, end = new TimeSpan(17, 0, 0), start = new TimeSpan(9, 0, 0) }
                //      },
                Recommendations = ""
            });
            // addNanny(shifi_levy);
            addNanny(new Nanny
            {
                ID = "654",
                firstName = "Tsipi",
                lastName = "Hotoveli",
                Birthday = new DateTime(1989, 3, 29),
                Address = "HaRav Kuk St 8, Jerusalem",
                elevator = true,
                floor = 2,
                Expirence = 3,
                phone = "0521001001",
                MaxAge = 18,
                MinAge = 3,
                MaxChildren = 8,
                isPerHour = true,
                HourSalary = 10,
                monthSalary = 900,
                GovVacation = true,
                WorkWeek = new bool[] { true, true, true, true, true, false, false },
                TimeTable = new DayOfWork[]
            {
                            new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(17, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) }
            },
                Recommendations = ""
            });
            //         addNanny(Tsipi_Hotoveli);
            addNanny(new Nanny
            {
                ID = "904",
                firstName = "hanat",
                lastName = "uoveli",
                Birthday = new DateTime(1989, 5, 29),
                Address = "HaRav Kuk St 8, Jerusalem",
                elevator = true,
                floor = 4,
                Expirence = 3,
                phone = "0521211001",
                MaxAge = 24,
                MinAge = 6,
                MaxChildren = 10,
                isPerHour = true,
                HourSalary = 20,
                monthSalary = 900,
                GovVacation = true,
                WorkWeek = new bool[] { true, true, true, true, true, false, false },
                TimeTable = new DayOfWork[]
            {
                            new DayOfWork { day = 0, end = new TimeSpan(18, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(18, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(18, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(18, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(18, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(18, 0, 0), start = new TimeSpan(8, 0, 0) }
            },
                Recommendations = ""
            });
            addNanny(new Nanny
            {
                ID = "306",
                firstName = "tamar",
                lastName = "cohen",
                Birthday = new DateTime(1987, 5, 29),
                Address = "HaRav Kuk St 8, Jerusalem",
                elevator = true,
                floor = 1,
                Expirence = 9,
                phone = "0521300001",
                MaxAge = 20,
                MinAge = 3,
                MaxChildren = 7,
                isPerHour = true,
                HourSalary = 15,
                monthSalary = 1000,
                GovVacation = true,
                Recommendations = "",
                WorkWeek = new bool[] { true, true, true, true, true, true, false },
                TimeTable = new DayOfWork[]
        {
                            new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) }
        }
            });
            addNanny(new Nanny
            {
                ID = "500",
                firstName = "sara",
                lastName = "levy",
                Birthday = new DateTime(1983, 2, 15),
                Address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem, 93721",
                elevator = false,
                floor = 5,
                Expirence = 2,
                phone = "0586000001",
                MaxAge = 19,
                MinAge = 6,
                MaxChildren = 9,
                isPerHour = true,
                HourSalary = 12,
                monthSalary = 950,
                GovVacation = false,
                Recommendations = "",
                WorkWeek = new bool[] { true, true, true, true, true, true, false },
                TimeTable = new DayOfWork[]
            {
                            new DayOfWork { day = 0, end = new TimeSpan(14, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(14, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(14, 0, 0), start = new TimeSpan(7, 3, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) }
            },
            });
            addMother(new Mother
            {
                ID = "450",
                firstName = "sara",
                lastName = "kon",
                Birthday = new DateTime(1973, 2, 15),
                housePhone = "0586200021",
                cellPhone = "0586222222",
                address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem, 93721",
                searchArea = "HaRav Kuk St 8, Jerusalem",
                daysNeedNanny = new bool[] { true, true, true, true, true, true },
                serviseNeededTimeTable = new DayOfWork[]
            {
               new DayOfWork { day = 0, end = new TimeSpan(13, 0, 0), start = new TimeSpan(8, 0, 0) },
               new DayOfWork { day = 1, end = new TimeSpan(13, 0, 0), start = new TimeSpan(8, 0, 0) },
               new DayOfWork { day = 2, end = new TimeSpan(13, 0, 0), start = new TimeSpan(8, 0, 0) },
               new DayOfWork { day = 3, end = new TimeSpan(13, 0, 0), start = new TimeSpan(9, 0, 0) },
               new DayOfWork { day = 4, end = new TimeSpan(13, 0, 0), start = new TimeSpan(9, 0, 0) },
               new DayOfWork { day = 5, end = new TimeSpan(13, 0, 0), start = new TimeSpan(9, 0, 0) }
            },
                isSingalParent = false,
                comments = ""
            });
            addMother(new Mother
            {
                ID = "961",
                firstName = "mushka",
                lastName = "levin",
                Birthday = new DateTime(1976, 2, 14),
                housePhone = "0582220021",
                cellPhone = "0581112222",
                address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem, 93721",
                searchArea = "HaRav Kuk St 8, Jerusalem",
                daysNeedNanny = new bool[] { true, true, true, true, true, false },
                serviseNeededTimeTable = new DayOfWork[]
           {
                            new DayOfWork { day = 0, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(14, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(14, 0, 0), start = new TimeSpan(9, 0, 0) }
        },
                isSingalParent = false,
                comments = ""
            });
            addMother(new Mother
            {
                ID = "482",
                firstName = "chana",
                lastName = "israel",
                Birthday = new DateTime(1978, 2, 14),
                housePhone = "0577770021",
                cellPhone = "0586666222",
                address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem, 93721",
                searchArea = "HaRav Kuk St 8, Jerusalem",
                daysNeedNanny = new bool[] { true, true, true, true, true, false },
                serviseNeededTimeTable = new DayOfWork[]
           {
                            new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 2, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 3, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 4, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) },
                            new DayOfWork { day = 5, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 0, 0) }
           },
                isSingalParent = false,
                comments = ""
            });
            addChild(new Child
            {
                ID = "120",
                firstName = "yeude",
                lastName = "israel",
                Birthday = new DateTime(2016, 2, 14),
                MotherID = "482",
                hasSpecialNeeds = false,
                specificationOfNeeds = ""
            });
            addChild(new Child
            {
                ID = "783",
                firstName = "moshe",
                lastName = "levin",
                Birthday = new DateTime(2016, 11, 14),
                MotherID = "961",
                hasSpecialNeeds = false,
                specificationOfNeeds = ""
            });
            addChild(new Child
            {
                ID = "783",
                firstName = "chaim",
                lastName = "kon",
                Birthday = new DateTime(2016, 11, 14),
                MotherID = "450",
                hasSpecialNeeds = false,
                specificationOfNeeds = ""
            });
        }

    }
}