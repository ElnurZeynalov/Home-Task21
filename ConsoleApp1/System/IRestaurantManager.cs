using MainPart;
using MainPart.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantSystem
{
    public interface IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; set; }
        public List<Order> Orders { get; set; }

        public void AddOrder(Order order, List<OrderItem> orderItems);
        public void RemoveOrder(int? no);
        public List<Order> GetOrdersByDatesInterval(DateTime start,DateTime end);
        public List<Order> GetOrderByDate(DateTime dateTime);
        public List<Order> GetOrdersByPriceInterval(double minPrice,double maxPrice);
        public Order GetOrderByNo(int? no);
        public void AddMenuItem(string name,double price,MenuCategory catecory);
        public void RemoveMenuItem(string no);
        public void EditMenuItem(string no,string newName,double newPrice);
        public List<MenuItem> GetMenuItemByCategory (MenuCategory? category);
        public List<MenuItem> GetMenuItemByPrice (double minPrice,double maxPrice);
        public List<MenuItem> GetMenuItemByName (string name);
    }
}
