using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public sealed class BLFactory
    {
        

        public class FactoryBL
        {
            static IBL bl = null;
            public static IBL GetBL()
            {
                if (bl == null)
                    bl = new MyBL();
                return bl;
            }
        }

    }
}