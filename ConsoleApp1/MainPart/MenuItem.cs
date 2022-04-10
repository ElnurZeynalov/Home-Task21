using MainPart.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart
{
    public class MenuItem
    {
        private string _no;
        public string No { get;}
        public string  Name { get; set; }
        public double Price { get; set; }
        public MenuCategory Category { get; set; }
        private static int category_1 = 100;
        private static int category_2 = 100;
        private static int category_3 = 100;
        private static int category_4 = 100;
        private static int category_5 = 100;
        public MenuItem(string name,double price,MenuCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
            if (category == (MenuCategory)1)
            {
                category_1++;
                _no = Convert.ToString(category).Substring(0,2).ToUpper()+category_1;
                No = _no;
            }
            else if (category == (MenuCategory)2)
            {
                category_2++;
                _no = Convert.ToString(category).Substring(0, 2).ToUpper() + category_2;
                No = _no;
            }
            else if (category == (MenuCategory)3)
            {
                category_3++;
                _no = Convert.ToString(category).Substring(0, 2).ToUpper() + category_3;
                No = _no;
            }
            else if (category == (MenuCategory)4)
            {
                category_4++;
                _no = Convert.ToString(category).Substring(0, 2).ToUpper() + category_4;
                No = _no;
            }
            else if (category == (MenuCategory)5)
            {
                category_5++;
                _no = Convert.ToString(category).Substring(0, 2).ToUpper() + category_5;
                No = _no;
            }
        }
        public string ShowInfo()
        {
            return $"No: {this.No} - Name: {this.Name} - Price: {this.Price} - Category: {this.Category}";
        }
    }
}
