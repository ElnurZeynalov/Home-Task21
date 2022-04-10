using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainPart;
using MainPart.Enums;

namespace ConsoleApp1
{
    internal class Metods
    {
        public static double PriceChecker(string text1,string text2)
        {
            double value;
            string valueStr;
            do
            {
            do
            {
               Console.Write(text1);
                valueStr = Console.ReadLine();
                    if (!double.TryParse(valueStr, out value))
                        Console.WriteLine(text2);
            } while (!double.TryParse(valueStr,out value));
                value = Convert.ToDouble(valueStr);
            } while (value<0);
            return value;
        }

        public static MenuCategory CategoryChecker(string text1, string text2,string text3)
        {
            int value;
            string valueStr;
            MenuCategory test;
            do
            {
                do
                {
                    int num = 0;
                    foreach (var item in Enum.GetValues(typeof(MenuCategory)))
                    {
                        num++;
                        Console.WriteLine(num +" - "+item);
                    }
                    Console.Write(text1);
                    valueStr = Console.ReadLine();
                    if (!int.TryParse(valueStr, out value))
                        Console.WriteLine(text2);
                } while (!int.TryParse(valueStr, out value));
                value = Convert.ToInt32(valueStr);
                test = (MenuCategory)value;
                if(!Enum.IsDefined(typeof(MenuCategory), value))
                    Console.WriteLine(text3);
            } while (!Enum.IsDefined(typeof(MenuCategory),value));
           return (MenuCategory)value;
        }
        public static bool PriceIntervalChecker(double minPrice,double maxPrice)
        {
            if (maxPrice < minPrice)
                return true;
            return false;

        }
        public static int PositiveIntChecker(string text1,string text2)
        {
            int value;
            string valueStr;
            do
            {
                do
            {
                Console.Write(text1);
                valueStr = Console.ReadLine();
                if(!int.TryParse(valueStr, out value))
                    Console.WriteLine(text2);
            } while (!int.TryParse(valueStr,out value));
                value = Convert.ToInt32(valueStr);
            } while (value<=0);
            return value;
        }
    }
}
