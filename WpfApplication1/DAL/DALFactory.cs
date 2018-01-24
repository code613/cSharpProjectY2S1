using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFactory
    {

        static Idal dal = null;
        public static Idal getDAL()
        {
            if (dal == null)
                dal = new Dal_imp();
            return dal;
        }
    }
}
