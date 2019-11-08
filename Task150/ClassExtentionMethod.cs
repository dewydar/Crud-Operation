using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task150
{
    static class ClassExtentionMethod
    {
        public static string checkName(this string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You Make Some Error");
                Console.Write("Please Enter Again : ");
                name = Console.ReadLine();
                return checkName(name);
            }
            else if (name.Length > 5)
            {
                Console.WriteLine("You Make Some Error");
                Console.Write("Please Enter Again : ");
                name = Console.ReadLine();
                return checkName(name);
            }
            else
                return name.ToUpper();
        }
        public static string checkChar(this string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You Make Some Error");
                Console.Write("Please Enter Again : ");
                name = Console.ReadLine();
                return checkChar(name);
            }
            else
                return name;
        }
        //public static int checkOId(this int id)
        //{
        //    do{
        //         Console.WriteLine("You Make Some Error");
        //         Console.Write("Please Enter Again : ");
        //    } while (!(int.TryParse(Console.ReadLine(),out id)));
        //        return checkOId(id);
        //}
        //public static tsource checkMoney<tsource>(tsource money)
        //{
        //    if (money.GetType().ToString() == "double")
        //    {
        //        double x;
        //        do
        //        {
        //            Console.WriteLine("You Make Some Error");
        //            Console.Write("Please Enter Again : ");
        //        } while (!(double.TryParse(Console.ReadLine(),out x)));
        //    }
        //    else if(money.GetType().ToString() == "int")
        //    {
        //        int x;
        //        do
        //        {
        //            Console.WriteLine("You Make Some Error");
        //            Console.Write("Please Enter Again : ");
        //        } while (!(int.TryParse(Console.ReadLine(), out x)));
        //    }
        //    else if(money.GetType().ToString()=="decimal")
        //    {
        //        decimal x;
        //        do
        //        {
        //            Console.WriteLine("You Make Some Error");
        //            Console.Write("Please Enter Again : ");
        //        } while (!(decimal.TryParse(Console.ReadLine(), out x)));
        //    }
        //    return money;
        //}
    }
}
