using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLFactory
    {

        private static IBL instance = null;

        public static IBL getBL()
        {
            if (instance == null)
            {
                instance = new MyBL();
            }
            return instance;
        }
    }
}
