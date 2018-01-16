using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
         double salary(Contract con);
        List<Nanny> matchingNannies(Mother mo, Child ch);
         IEnumerable<Nanny> proximityNannies(Mother mom);
        List<Child> childrenWithoutNanny();
        List<Nanny> vocationAcordingToGov();
        IEnumerable<Contract> contractFeetToCondition(Func<Contract, bool> someDel);
        IEnumerable<int> conFeetToCondition(Func<Contract, bool> someDel);
        IEnumerable<IGrouping<int, Nanny>> perAge(bool maxAge = false);
        IEnumerable<IGrouping<int, Nanny>> Distance(Mother mo,myEnum.TipeOfTravel t);
        
        void addNanny(Nanny nan);
        void deleteNanny(string id);
        void updateNannyDetalis(Nanny nan);

        void addMother(Mother mom);
        void deleteMother(string id);
        void updateMotherDetalis(Mother mom);

        void addChild(Child ch);
        void deleteChild(string id);
        void updateChildDetalis(Child ch);

        void addContract(Contract con);
        void deleteContract(int number);
        void updateContractDetalis(Contract con);

        List<Nanny> getListOfNannies(Func <Nanny,bool> predicate);
        List<Mother> getListOfMothers(Func<Mother, bool> predicate);
        List<Child> getListOfMothersChildren(Mother mom);
        List<Contract> getListOfContracts(Func<Contract, bool> predicate);
        List<Child> getListOfChildren(Func<Child, bool> predicate);
    }
}
