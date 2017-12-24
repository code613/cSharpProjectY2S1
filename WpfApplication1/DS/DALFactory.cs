using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{

    public sealed class DalFactory
    {
        #region Singleton
        private static readonly DalFactory instance = new DalFactory();

        static DalFactory() { }
        private DalFactory() { }

        public static DalFactory Instance
        {
            get { return instance; }
        }
        #endregion
    }
}
