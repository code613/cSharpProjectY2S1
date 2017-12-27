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
        public Person find(string ID)///need to fix
        {
            List<Mother> help = getListOfMothers();
            List<Child> help1 = getListOfChildren();
            List<Nanny> help2 = getListOfNannies();
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
            throw "the person was not found";
        }
        public void addChild(Child ch )
        {
            throw new NotImplementedException();
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

        public List<Mother> getListOfMothersChildren()
        {
            throw new NotImplementedException();
        }

        public List<Nanny> getListOfNannies()
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

        public List<Child> getListOfChildren()
        {
            throw new NotImplementedException();
        }
    }
}
