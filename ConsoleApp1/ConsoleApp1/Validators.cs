using System;
using System.Collections.Generic;
using System.Text;
using MainPart;
using RestaurantSystem;

namespace ConsoleApp1
{
    internal class Validators
    {
        static IRestaurantManager _managment = new RestaurantManager();
        public static bool MenuItemIsExist(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return true;
            if(_managment.MenuItems == null)  
                return false;
                if(!_managment.MenuItems.Exists(x=>x.Name == name))
                    return false;
                return true;
        }
        public static bool MenuItemNoIsExist(string no)
        {
            if (string.IsNullOrWhiteSpace(no))
                return true;
            if(!_managment.MenuItems.Exists(x=>x.No == no))
                return false;
            return true;
        }
        public static bool OrderNoIsExist(int? no)
        {
            if (no == null)
                return true;
            if (!_managment.Orders.Exists(x => x.No == no))
                return false;
            return true;
        }
    }
}
