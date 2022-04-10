using MainPart;
using MainPart.Enums;
using MainPart.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantSystem
{
    public class RestaurantManager : IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public  List<Order> Orders { get; set; } = new List<Order>();
        public void AddMenuItem(string name, double price, MenuCategory catecory)
        {
            var item = MenuItems.Find(x=> x.Name == name);
            if (item == null)
            {
                MenuItem menuItem = new MenuItem(name, price, catecory);
                MenuItems.Add(menuItem);
                Console.WriteLine($"No: {menuItem.No} MenuItem elave edildi");
            }
            else
                throw new IsExistException("Bu adda item movcuddur");
        }

        public void AddOrder(Order order, List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Order.OrderItems.Add(item.MenuItem);
                }
            }
            Orders.Add(order);
        }

        public void EditMenuItem(string no, string newName, double newPrice)
        {
            var item = MenuItems.Find(x => x.No == no);
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(newName))
                    throw new NullReferenceException();
                item.Name = newName;
                if (newPrice <= 0)
                    throw new MealIsNotFreeException("Qiymet 0 veya 0-dan kicik ola bilmez ");
                item.Price = newPrice;
            }
            else if (item == null)
                throw new NotFoundException("Bu No da item yoxdur");
        }

        public List<MenuItem> GetMenuItemByCategory(MenuCategory? category)
        {
            if (category == null)
                throw new NullReferenceException("Bu category movcud deyil");
            var items = MenuItems.FindAll(x => x.Category == category);
            if (items == null)
                throw new NotFoundException("Bu category da item menuya elave olunmuyub");
            return items;
        }

        public List<MenuItem> GetMenuItemByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException();
            var items = MenuItems.FindAll(x=> x.Name.Contains(name));
            if (items == null)
                throw new NotFoundException("Bu adda item yoxdur");
            return items;
        }
        public List<MenuItem> GetMenuItemByPrice(double minPrice = 0, double maxPrice = 0)
        {
            if (maxPrice < minPrice)
                throw new IntervalException("maksimum qiymet min kicik ola bilmez");
              var items = MenuItems.FindAll(x=> x.Price >= minPrice && x.Price <= maxPrice);
            if (items == null)
                throw new NotFoundException("Bu qiymet araliginda item movcu deyil");
            return items;
        }

        public List<Order> GetOrderByDate(DateTime dateTime)
        {
            if (dateTime == null)
                throw new NullReferenceException();
            var orders = Orders.FindAll(x => x.Date.Date ==  dateTime.Date);
            if (orders == null)
                throw new NotFoundException("Bu zaman araliginda order yoxdur");
            return orders;
        }

        public Order GetOrderByNo(int? no)
        {
            if (no == null)
                throw new ValueIsNullException("Null bir deyer axdarila bilmez");
            var order = Orders.Find(x => x.No == no);
            if (order == null)
                throw new NotFoundException("Bu no da bir order yoxdur");
            return order;
        }
        public List<Order> GetOrdersByDatesInterval(DateTime start, DateTime end)
        {
            if (start == null || end == null) 
                throw new NullReferenceException();
            if (end < start)
                throw new IntervalException("evvel kecmis sonra gelecek zaman yazilmalidir");
            var orders = Orders.FindAll(x=>x.Date>=start && x.Date<=end);
            if (orders == null)
                throw new NotFoundException("Bu intervalda order yoxdur");
            return orders;
        }

        public List<Order> GetOrdersByPriceInterval(double minPrice = 0, double maxPrice = 0)
        {
            if (maxPrice < minPrice)
                throw new IntervalException("maksimum qiymet min kicik ola bilmez");
            var orders = Orders.FindAll(x=>x.TotalAmount>=minPrice && x.TotalAmount<=maxPrice);
            if (orders == null)
                throw new NotFoundException("Bu intervalda order yoxdur");
            return orders;
        }

        public void RemoveMenuItem(string no)
        {
            if(string.IsNullOrWhiteSpace(no))
                throw new NullReferenceException();
            var item = MenuItems.Find(x=>x.No==no);
            if (item == null)
                throw new NotFoundException("Bu no da bir item yocdur");
            MenuItems.Remove(item);
            Console.WriteLine($"No: {no} - item silindi");
        }

        public void RemoveOrder(int? no)
        {
            if (no == null)
                throw new ValueIsNullException("Null bir deyer siline bilmez");
            var order = Orders.Find(x => x.No == no);
            if (order == null)
                throw new NotFoundException("Bu no da bir order yoxdur");
            Orders.Remove(order);
            Console.WriteLine($"No: {no} - order silindi");
        }
    }
}
