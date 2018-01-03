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
        void addNanny(Nanny nan);
        void deleteNanny(Nanny nan);
        void updateNannyDetalis(Nanny nan,string last_name);

        void addMother(Mother mom);
        void deleteMother(Mother mom);
        void updateMotherDetalis(Mother mom,string commands);

        void addChild(Child ch);
        void deleteChild(Child ch);
        void updateChildDetalis(Child ch,string needs);

        void addContract(Contract co);
        void deleteContract(Contract co);
        void updateContractDetalis(Contract co);

        List<Child> getListOfChildren();
        List<Nanny> getListOfNannies();
        List<Mother> getListOfMothers();
        List<Child> getListOfMothersChildren();
        List<Contract> getListOfContracts();


    }
}
