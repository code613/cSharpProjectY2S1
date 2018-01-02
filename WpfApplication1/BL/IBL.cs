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
        void deleteNanny(Nanny nan);
        void updateNannyDetalis(Nanny nan);

        void addMother(Mother mom);
        void deleteMother(Mother mom);
        void updateMotherDetalis(Mother mom);

        void addChild(Child ch);
        void deleteChild(Child ch);
        void updateChildDetalis(Child ch);

        void addContract(Contract co);
        void deleteContract(Contract co);
        void updateContractDetalis(Contract co);

        List<int> getListOfNannies();
        List<int> getListOfMothers();                                              
        List<int> getListOfChildrenMother();
        List<int> getListOfContracts();
    }
}


