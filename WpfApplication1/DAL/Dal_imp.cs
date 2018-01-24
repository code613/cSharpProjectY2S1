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
        #region Singleton
        private static readonly Dal_imp instance = new Dal_imp();

        public static Dal_imp Instance
        {
            get { return instance; }
        }
        #endregion
        private Dal_imp()
        {       

        }
        protected static Dal_imp dal;

        public static Dal_imp Dal
        {
            get
            {
                if (dal == null)
                    dal = new Dal_imp();
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

       
    }
}