using ABC_Hardware.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.DAL;
namespace ABC_Hardware.BLL
{
    public class ABCPOS
    {
        public int ProcessSale(Sale abcsale)
        {
            int saleNumber =0;
            ABCSales ABCHardware = new ABCSales();
            saleNumber = ABCHardware.ProcessASale(abcsale);
            return saleNumber;
        }

    }
}
