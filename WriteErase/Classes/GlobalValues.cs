using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteErase.Classes
{
    public static class GlobalValues
    {
        // Класс с глобальными значениями
       public static List<DataBase.Product> listOrder;
        public static bool isFirstEnterIntoPageOrder;
        public static decimal totalPriceWithoutDiscount;
        public static decimal totalPrice;
        public static int orderID;
        public static int role;
        public static int idUser;
        public static string captchaText;
        public static int attemp;

    }
}
