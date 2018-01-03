using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;

namespace DAL
{

    class Dal_imp : Idal
    {

        public void addChild(Child ch)
        {

        }

        public void addContract(Contract con)
        {
            throw new NotImplementedException();
        }

        public void addMother(Mother mom)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny nan)
        {
            throw new NotImplementedException();
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

        public List<Contract> getListOfContracts()
        {
            throw new NotImplementedException();
        }

        public List<Mother> getListOfMothers()
        {
            throw new NotImplementedException();
        }

        public List<Child> getListOfMothersChildren()
        {
            throw new NotImplementedException();
        }

        public List<Nanny> getListOfNannies()
        {
            throw new NotImplementedException();
        }

        public void updateChildDetalis(Child ch,string needs)
        {
            throw new NotImplementedException();
        }

        public void updateContractDetalis(Contract con)
        {
            throw new NotImplementedException();
        }

        public void updateMotherDetalis(Mother mom,string comands)
        {
            throw new NotImplementedException();
        }

        public void updateNannyDetalis(Nanny nan, string last_name)
        {
            List<Nanny> nannyList = getListOfNannies();
            var nanny = nannyList.Where(n => n.ID == nan.ID).FirstOrDefault();
            if (nanny != null)
            {
                nanny.lastName = last_name;
            }
        }

        public List<Child> getListOfChildren()
        {
            throw new NotImplementedException();
        }
    }
}
