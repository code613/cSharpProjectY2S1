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

        List<int> getListOfNannies();//and then recive it in VAR; or just send a IEnumerable
        List<int> getListOfMothers();//and can covert with ToList().    
                                     //no diff from String and string (like int and System.Int32)
                                     //rather genirlly practiced to use sting for object and
                                     //String refiring spaciflly to the class
        List<int> getListOfMothersChildren();
        List<int> getListOfContracts();
    }
}


