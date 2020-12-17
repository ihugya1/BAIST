using ABC_Hardware.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.BLL
{
    public class ABCPOS
    {
        public int ProcessSale(ABCSales abcsale)
        {
            int saleNumber =0;
            ABCSales ABCHardware = new ABCSales();
           // saleNumber = ABCHardware.AddSale(abcsale);
            return saleNumber;
        }

    }
}
