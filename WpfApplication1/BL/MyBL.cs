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
       


        public void addChild(Child ch)
        {
            throw new NotImplementedException();
        }

        public void addContract(Contract con)
        {
            
        }

        


         public void addMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny nan)
        {
            if (is18(nan))
                MyDal.addNanny(nan);
        }

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

        public void deleteChild(Child ch)
        {
            throw new NotImplementedException();
        }

        public void deleteContract(Contract con)
        {
            throw new NotImplementedException();
        }

        public void deleteMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void deleteNanny(Nanny nan)
        {
            throw new NotImplementedException();
        }

        public List<int> getListOfContracts()
        {
            throw new NotImplementedException();
        }

        public List<int> getListOfMothers()
        {
            throw new NotImplementedException();
        }

        public List<int> getListOfMothersChildren()
        {
            throw new NotImplementedException();
        }

        public List<int> getListOfNannies()
        {
            throw new NotImplementedException();
        }

        public void updateChildDetalis(Child ch)
        {
            throw new NotImplementedException();
        }

        public void updateContractDetalis(Contract con)
        {
            throw new NotImplementedException();
        }

        public void updateMotherDetalis(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void updateNannyDetalis(Nanny nan)
        {
            throw new NotImplementedException();
        }

    }
}
