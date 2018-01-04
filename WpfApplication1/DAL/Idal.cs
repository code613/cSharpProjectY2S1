using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        #region nanny
        void addNanny(Nanny nan);
        void deleteNanny(string id);
        void updateNannyDetalis(Nanny nan);
        Nanny findNanny(string ID);
        #endregion

        #region mother
        void addMother(Mother mom);
        void deleteMother(string id);
        void updateMotherDetalis(Mother mom);
        Mother findMother(string ID);
        #endregion

        #region child
        void addChild(Child ch);
        void deleteChild(string id);
        void updateChildDetalis(Child ch);
        Child findChild(string ID);
        #endregion

        #region contract
        void addContract(Contract co);
        void deleteContract(int contractNum);
        void updateContractDetalis(Contract co);
        Contract findContract(int contractNum);
        #endregion
        
        List<Child> getListOfChildren();
        List<Nanny> getListOfNannies();
        List<Mother> getListOfMothers();
        List<Child> getListOfMothersChildren(Mother mom);
        List<Contract> getListOfContracts();


    }
}
