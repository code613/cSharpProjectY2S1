using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface Idal//what is a interface that it looks like a reguler class??
    {
        void addNanny();//maybe a nanny should be called care lady!?!
        void deleteNanny();//don't need to define what varibles reciving???
        void updateNannyDetalis();

        void addMother();
        void deleteMother();
        void updateMotherDetalis();

        void addChild();
        void deleteChild();
        void updateChildDetalis();

        void addContract();
        void deleteContract();
        void updateContractDetalis();

        List<int> getListOfNannies();//and then recive it in VAR; or just send a IEnumerable
        List<int> getListOfMothers();//and can covert with ToList().    
                                     //no diff from String and string (like int and System.Int32)
                                     //rather genirlly practiced to use sting for object and
                                     //String refiring spaciflly to the class
        List<int> getListOfMothersChildren();
        List<int> getListOfContracts();
    }
}
