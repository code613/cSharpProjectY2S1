using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLFactory
    {

         static IBL bl = null;
         public static IBL getBL()
         {
             if (bl == null)
                 bl = new MyBL();
             return bl;
         }
    }
}
