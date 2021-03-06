﻿using System;
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
        List<Nanny> getListOfNannies(Func<Nanny,bool> predicate = null);
        #endregion

        #region mother
        void addMother(Mother mom);
        void deleteMother(string id);
        void updateMotherDetalis(Mother mom);
        /// <summary>
        /// returns the mother by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Mother findMother(string ID);
        List<Mother> getListOfMothers(Func<Mother, bool> predicate = null);
        List<Child> getListOfMothersChildren(Mother mom);
        #endregion

        #region child
        void addChild(Child ch);
        void deleteChild(string id);
        void updateChildDetalis(Child ch);
        /// <summary>
        /// returns the mother by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Child findChild(string ID);
        List<Child> getListOfChildren(Func<Child, bool> predicate = null);
        #endregion

        #region contract
        void addContract(Contract co);
        void deleteContract(int contractNum);
        void updateContractDetalis(Contract co);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        Contract findContract(int contractNum);
        List<Contract> getListOfContracts(Func<Contract, bool> predicate=null);
        #endregion

    }
}



