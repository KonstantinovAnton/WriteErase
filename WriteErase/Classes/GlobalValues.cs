using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteErase.Classes
{
    public static class GlobalValues
    {
       public static List<DataBase.Product> listOrder;
        public static bool isFirstEnterIntoPageOrder;
        public static decimal totalPriceWithoutDiscount;
        public static decimal totalPrice;
        public static int orderID;
    }
}
