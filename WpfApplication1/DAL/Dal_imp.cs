using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;

namespace DAL
{

    public class Dal_imp : Idal
    {

        static Random r = new Random();

        #region child
        public void addChild(Child child)
        {

            Child ch = findChild(child.ID);
            if (ch != null)
                throw new Exception("child with the same id already exists...");
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
            if (mom == null)
                throw new Exception("mother  not found...");
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
        /*
         * 
          //// void init()  //tokk from MyBL
       // {
       //     Nanny shifi_levy = new Nanny
       //     {
       //         ID = "123",
       //         firstName = "shifi",
       //         lastName = "levy",
       //         Birthday = DateTime.Parse("31.12.88"),
       //         Address = "HaRav Shalom Shabazi St 12, Jerusalem",
       //         elevator = true,
       //         floor = 2,
       //         Expirence = 3,
       //         phone = "0529344513",
       //         MaxAge = 15,
       //         MinAge = 3,
       //         MaxChildren = 8,
       //         isPerHour = false,
       //         SallaryPerMonths = 900,
       //         GovVacation = false,
       //         WorkWeek = new bool[] { true, true, true, true, true, true, false },
       //         Recommendations = ""

       //     };
       //     Nanny Tsipi_Hotoveli = new Nanny
       //     {
       //         ID = "654",
       //         firstName = "Tsipi",
       //         lastName = "Hotoveli",
       //         Birthday = new DateTime(1989, 3, 29),
       //         Address = "HaRav Kuk St 8, Jerusalem",
       //         elevator = true,
       //         floor = 2,
       //         Expirence = 3,
       //         phone = "0521001001",
       //         MaxAge = 18,
       //         MinAge = 3,
       //         MaxChildren = 8,
       //         isPerHour = true,
       //         HourSallary = 10,
       //         SallaryPerMonths = 900,
       //         GovVacation = true,
       //         WorkWeek = new bool[] { true, true, true, true, true, false, false },



       //         Recommendations = ""
       //     };
       // }
        private void initNanysMothersandChilds()
        {
            addNanny(new Nanny
            {
                Address = "10, avenue de la paix, strasbourg, france",
                Birthday = new DateTime(1990, 3, 3),
                elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                lastName = "Baya",
                firstName = "sari",
                Floor = 2,
                ID = 300,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
{
                   new DayOfWork { day = 0, end = new TimeSpan(8, 30, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(9, 20, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(9, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(8, 0, 0), start = new TimeSpan(7, 0, 0) } ,
},

            });
            addNanny(new Nanny
            {
                Address = "14, avenue de la paix, strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman5",
                FirstName = "sari5",
                Floor = 2,
                Id = 301,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },

            });
            addNanny(new Nanny
            {
                Address = "20 rue de la paix, paris,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman1",
                FirstName = "sari1",
                Floor = 2,
                Id = 302,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
              {
                   new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(14, 0, 0), start = new TimeSpan(10, 30, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(19, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
              },

            });
            addNanny(new Nanny
            {
                Address = "10 rue des arquebusiers,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman3",
                FirstName = "sari3",
                Floor = 2,
                Id = 303,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
             {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(20, 0, 0), start = new TimeSpan(10, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
             },

            });
            addNanny(new Nanny
            {
                Address = "5 rue turenne,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 12,
                SalPerHour = 23,
                FamilyName = "gutman2",
                FirstName = "sari2",
                Floor = 2,
                Id = 304,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 1,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
           {
                   new DayOfWork { day = 0, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(12, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(11, 0, 0), start = new TimeSpan(7, 0, 0) } ,
           },

            });
            addNanny(new Nanny
            {
                Address = "40 avenue des vosges,strasbourg,france",
                Dob = new DateTime(1990, 3, 3),
                Elevator = true,
                ExpYears = 1,
                SalPerHour = 23,
                FamilyName = "gutman4",
                FirstName = "sari4",
                Floor = 2,
                Id = 305,
                Phone = "0548455555",
                IsSalPerHour = true,
                IsTamat = false,
                MaxAgeMonth = 36,
                MaxChildren = 5,
                SalPerMonth = 4000,
                MinAgeMonth = 4,
                DaysOfWork = new bool[] { true, true, true, true, true, true },
                Week_of_work = new DayOfWork[]
             {
                   new DayOfWork { day = 0, end = new TimeSpan(15, 0, 0), start = new TimeSpan(7, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(15, 0, 0), start = new TimeSpan(9, 20, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(15, 30, 0), start = new TimeSpan(7, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(15, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(17, 45, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(10, 0, 0), start = new TimeSpan(7, 0, 0) } ,
             },

            });

            addNanny(new Nanny
            {
                Address = "120 Pesach Chevroni,Jerusalem",
                FirstName = "Ruhami",
                FamilyName = "Vorona",
                Id = 306,

                //rangeOfAge="gg",

                Dob = new DateTime(1996, 09, 22),
                MaxChildren = 8,
                MinAgeMonth = 0,
                MaxAgeMonth = 6,
                Elevator = false,
                SalPerHour = 40,
                SalPerMonth = 4000,
                Recommendations = "good",
                Phone = "0543216766",
                ExpYears = 0,
                Floor = 1,
                IsSalPerHour = true,
                IsTamat = false,
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                DaysOfWork = new bool[] { true, true, true, true, true, true },

            });
            addNanny(new Nanny
            {
                Address = "10 avenue des vosges,strasbourg",
                FirstName = "Sarah",
                FamilyName = "Cohen",
                Id = 307,

                //rangeOfAge="gg",

                Dob = new DateTime(1970, 09, 22),
                MaxChildren = 8,
                MinAgeMonth = 0,
                MaxAgeMonth = 6,
                Elevator = false,
                SalPerHour = 40,
                SalPerMonth = 4000,
                Recommendations = "good",
                Phone = "0543216766",
                ExpYears = 0,
                Floor = 1,
                IsSalPerHour = true,
                IsTamat = true,
                Week_of_work = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(18, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                 },
                DaysOfWork = new bool[] { true, false, true, true, true, true },

            });


            addMother(new Mother
            {
                MotherAddress = "14 avenue de la paix,strasbourg,france",
                Id = 203,
                FirstName = "Avia",
                FamilyName = "Abitan",
                Phone = "056787677",
                ResearchAddress = "14 avenue de la paix,strasbourg,france",
                Remarks = "not good",
                Day_of_keep = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });
            addMother(new Mother
            {
                MotherAddress = "12 allee de la robertsau,strasbourg",
                Id = 202,
                FirstName = "Chaya",
                FamilyName = "Levi",
                Phone = "056787677",
                ResearchAddress = "Jerusalem Pesach Chevroni 120 Israel",
                Remarks = "not good",
                Day_of_keep = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(9, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(11, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },
            });
            addMother(new Mother
            {
                FamilyName = "geleer",
                Phone = "0556691448",
                ResearchAddress = "4 rue strauss durkheim,strasbourg",
                FirstName = "chaya",
                Id = 200,
                MotherAddress = "פסח חברוני 120, ירושלים",
                Day_of_keep
    = new DayOfWork[]
    {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
    },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });
            addMother(new Mother
            {
                FamilyName = "cohen",
                Phone = "0556691448",
                ResearchAddress = "2 avenue des vosges, strasbourg",
                FirstName = "rivki",
                Id = 201,
                MotherAddress = "פסח חברוני 120, ירושלים",
                Day_of_keep
                = new DayOfWork[]
                {
                   new DayOfWork { day = 0, end = new TimeSpan(17, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 1, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 2, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 3, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 4, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                   new DayOfWork { day = 5, end = new TimeSpan(16, 0, 0), start = new TimeSpan(8, 0, 0) } ,
                },
                NeedsDay = new bool[] { true, true, true, true, true, true },

            });

            addChild(new Child
            {
                Id = 100,
                DobChild = new DateTime(2014, 11, 27),
                FirstName = "yosi",
                IsSpecialNeeds = false,
                MotherId = 200

            });
            addChild(new Child
            {
                Id = 101,
                DobChild = new DateTime(1990, 4, 28),
                FirstName = "yosi2",
                IsSpecialNeeds = false,
                MotherId = 200
            });
            addChild(new Child
            {
                Id = 102,
                DobChild = new DateTime(2015, 4, 28),
                FirstName = "yosi5",
                IsSpecialNeeds = true,
                MotherId = 201
            });
            addChild(new Child
            {
                Id = 103,
                DobChild = new DateTime(2016, 4, 28),
                FirstName = "yosi7",
                IsSpecialNeeds = false,
                MotherId = 201
            });



            addContract(contract: new Contract
            {
                Id_Nanny = 300,
                IdChild = 100,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });
            addContract(contract: new Contract
            {
                Id_Nanny = 301,
                IdChild = 101,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });
            addContract(contract: new Contract
            {
                Id_Nanny = 300,
                IdChild = 102,
                EndDate = new DateTime(2017, 12, 30),
                StartDate = new DateTime(2017, 11, 30),
                IsPerMonth = true,
                IsSigned = true,
                Sal_Per_Hour = 30,
                Sal_Per_Month = 4500,
                Theyknow = false
            });
            */
    }
}