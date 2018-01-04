using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface  IBL
    {

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

        List<Nanny> getListOfNannies();
        List<Mother> getListOfMothers();                                              
        List<Child> getListOfMothersChildren(Mother mom);
        List<Contract> getListOfContracts();
        List<Child> getListOfChildren();
    }
}


