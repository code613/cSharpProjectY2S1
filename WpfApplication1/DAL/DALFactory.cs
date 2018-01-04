using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class DALFactory
    {
        public class FactoryDAL
        {
            static Idal MyDal = null;
            public static Idal GetDAL()
            {
                if (MyDal == null)
                    MyDal = new Dal_imp();
                return MyDal;
            }
        }

    }
}
