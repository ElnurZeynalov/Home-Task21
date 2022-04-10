using System;
using System.Collections.Generic;
using MainPart;
using MainPart.Enums;
using RestaurantSystem;

namespace ConsoleApp1
{
    internal class Program
    {
        static IRestaurantManager _managment;
        static void Main(string[] args)
        {
            _managment = new RestaurantManager();
            bool exit = false;
            string choise;
            do
            {
                Console.WriteLine("\n===============MainManu==================\n");
                Console.WriteLine("-1 Menu uzerinde emeliyyat aparmaq\n-2 Sifarisler uzerinde emeliyyat aparmaq\n-0 Sistemden cixmaq");
                Console.Write("Secimi daxil edin: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        MenuOperation();
                        break;
                    case "2":
                        OrderOperation();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\n0-2 arasi bir deyer daxil edin !\n");
                        break;
                }
            } while (!exit);
        }
        static void MenuOperation()
        {
            bool exit = false;
            string choise;
            do
            {
                menu:
                Console.WriteLine("\n===============Menu==================\n");
                Console.WriteLine("- 1 Yeni item elave et");
                Console.WriteLine("- 2 Item uzerinde duzelis et ");
                Console.WriteLine("- 3 Item sil ");
                Console.WriteLine("- 4 Butun Item-lari goster ");
                Console.WriteLine("- 5 Categoriyasina gore menu item-lari goster ");
                Console.WriteLine("- 6 Qiymet araligina gore menu item-lar goster");
                Console.WriteLine("- 7 Menu item-lar arasinda ada gore axtaris et (search)");
                Console.WriteLine("- 0 Evvelki menuya qayit");
                Console.Write("Secimi daxil edin: ");
                choise= Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Console.Write("Elave Olunacaq item adi: ");
                        string name = Console.ReadLine();
                        while (Validators.MenuItemIsExist(name))
                        {
                            Console.WriteLine("\nBu adda item menuda movcuddur veya Item adi null veya bosluq ola bilmez ! \n");
                            goto menu;
                        }
                        double price = Metods.PriceChecker("Item qiymetini daxil edin: ", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        MenuCategory menuCategory = Metods.CategoryChecker("Item Categorysini daxil edin: ", "Yalniz Reqerm Daxil edin", "Bu Category Movcud detil");
                        _managment.AddMenuItem(name,price,menuCategory);
                        break;
                    case "2":
                        foreach (var item in _managment.MenuItems)
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        Console.WriteLine("Deyisdirilecek menu item no sunu daxil edin");
                        Console.Write("No: ");
                        string no = Console.ReadLine();
                        while (Validators.MenuItemNoIsExist(no))
                        {
                            Console.WriteLine("Bu id movcud deyil veya duzgun daxil edilmeyib");
                            goto menu;
                        }
                        Console.WriteLine("Yeni adi daxil edin");
                        string newName = Console.ReadLine();
                        double newPrice = Metods.PriceChecker("Item yeni qiymetini daxil edin", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        _managment.EditMenuItem(no,newName,newPrice);
                        break;
                    case "3":
                        foreach (var item in _managment.MenuItems)
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        Console.WriteLine("Silinecek menu item no sunu daxil edin");
                        Console.Write("No: ");
                        no = Console.ReadLine();
                        while (Validators.MenuItemNoIsExist(no))
                        {
                            Console.WriteLine("Bu id movcud deyil veya duzgun daxil edilmeyib");
                            goto menu;
                        }
                        _managment.RemoveMenuItem(no);
                        break;
                    case "4":
                        foreach (var item in _managment.MenuItems)
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        break;
                    case "5":
                        menuCategory = Metods.CategoryChecker("Item Categorysini daxil edin: ", "Yalniz Reqerm Daxil edin", "Bu Category Movcud detil");
                        foreach (var item in _managment.GetMenuItemByCategory(menuCategory))
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        break;
                    case "6":
                        double minPrice = Metods.PriceChecker("Minimim qiymeti daxil edin", "Axdarilacaq qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        double maxPrice = Metods.PriceChecker("Maximum qiymeti daxil edin", "Axdarilacaq qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        while (Metods.PriceIntervalChecker(minPrice,maxPrice))
                        {
                            Console.WriteLine("Max qiymet min kicik ola bilmez");
                            minPrice = Metods.PriceChecker("Item qiymetini daxil edin", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                            maxPrice = Metods.PriceChecker("Item qiymetini daxil edin", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        }
                        foreach (var item in _managment.GetMenuItemByPrice(minPrice, maxPrice))
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        break;
                    case "7":
                        Console.Write("Axdarilacq adi daxil edin: ");
                        name = Console.ReadLine();
                        foreach (var item in _managment.GetMenuItemByName(name))
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        break;
                    case "0":
                        exit=true;
                        Console.WriteLine("Esas menuya qayidilir");
                        break;
                    default:
                        Console.WriteLine("\n0-7 arasi bir deyer daxil edin !\n");
                        break;
                }
            } while (!exit);
        }
        static void OrderOperation()
        {
            bool exit = false;
            string choise;
            do
            {
                order:
                Console.WriteLine("\n=================Order==================\n");
                Console.WriteLine("- 1 Yeni sifaris elave etmek");
                Console.WriteLine("- 2 Sifarisin legvi ");
                Console.WriteLine("- 3 Butun sifarislerin ekrana cixarilmasi");
                Console.WriteLine("- 4 Verilen tarix araligina gore sifarislrein gosterilmesi");
                Console.WriteLine("- 5 Verilen mebleg araligina gore sifarislerin gosterilmesi");
                Console.WriteLine("- 6 Verilmis bir tarixde olan sifarislerin gosterilmesi");
                Console.WriteLine("- 7 Verilmis nomreye esasen hemin nomreli sifarisin melumatlarinin gosterilmesi");
                Console.WriteLine("- 0 Evveli menuya qayit");
                Console.Write("Secimi daxil edin: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        foreach (var item in _managment.MenuItems)
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        Console.WriteLine("Nece eded mehsu sifaris edeceksiniz ?");
                        int value = Metods.PositiveIntChecker("Miqdar: ", "Yalniz reqem daxil edin ve 0 dan boyuk olsun");
                        Order order = new Order();
                        double totalPrice = 0;
                        List<OrderItem> orderItems = new List<OrderItem>();
                        for (int i = 0; i < value; i++)
                        {
                            Console.WriteLine("Sifaris olunacaq item No daxil edin");
                            Console.Write("No: ");
                            string no = Console.ReadLine();
                            while (Validators.MenuItemNoIsExist(no))
                            {
                                Console.WriteLine("Bu id movcud deyil veya duzgun daxil edilmeyib");
                                no = Console.ReadLine();
                            }
                            int itemCount = Metods.PositiveIntChecker("Miqdar: ", "Yalniz reqem daxil edin ve 0 dan boyuk olsun");
                            OrderItem orderItem = new OrderItem();
                            orderItem.MenuItem = _managment.MenuItems.Find(x=> x.No == no);
                            orderItem.Count = itemCount;
                            totalPrice += orderItem.MenuItem.Price * itemCount;
                            orderItems.Add(orderItem);
                        }
                        order.TotalAmount=totalPrice;
                        _managment.AddOrder(order, orderItems);
                        foreach (var item in orderItems)
                        {
                            Console.WriteLine(item.MenuItem.ShowInfo());
                        }
                        foreach (var item in _managment.Orders)
                        {
                            item.LargeShowInfo();
                        }
                        break;
                    case "2":
                        foreach (var item in _managment.MenuItems)
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        Console.WriteLine("Silinecek order no sunu daxil edin");
                        int OredrNo = Metods.PositiveIntChecker("No: ", "Yalsniz reqem daxil edin");
                        while (Validators.OrderNoIsExist(OredrNo))
                        {
                            Console.WriteLine("Bu id movcud deyil veya duzgun daxil edilmeyib");
                            goto order;
                        }
                        _managment.RemoveOrder(OredrNo);
                        break;
                    case "3":
                        foreach (var item in _managment.Orders)
                        {
                            item.LargeShowInfo();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Hansi vaxdan etibaren oredrler siyahisi ekrana cixarilsin?   Numune:AY-Gun-Il");
                        Console.Write("Baslangic vaxti: ");
                        DateTime startTime = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Hansi vaxda qeder orderler Cixarilsin?");
                        Console.Write("Bitis vaxti: ");
                        DateTime endTime = Convert.ToDateTime(Console.ReadLine());
                        foreach (var item in _managment.GetOrdersByDatesInterval(startTime, endTime))
                        {
                            Console.WriteLine(item.NormalShowInfo()); 
                        }
                        break;
                    case "5":
                        double minPrice = Metods.PriceChecker("Minimim qiymeti daxil edin", "Axdarilacaq qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        double maxPrice = Metods.PriceChecker("Maximum qiymeti daxil edin", "Axdarilacaq qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        while (Metods.PriceIntervalChecker(minPrice, maxPrice))
                        {
                            Console.WriteLine("Max qiymet min kicik ola bilmez");
                            minPrice = Metods.PriceChecker("Item qiymetini daxil edin", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                            maxPrice = Metods.PriceChecker("Item qiymetini daxil edin", "Item qiymeti yalniz reqem ve 0dan boyuk olmalidir ");
                        }
                        foreach (var item in _managment.GetOrdersByPriceInterval(minPrice, maxPrice))
                        {
                            Console.WriteLine(item.NormalShowInfo()); 
                        }
                        break;
                    case "6":
                        Console.WriteLine("Hansi gun erzinde olan orderleri axadirisiniz?");
                        Console.Write("Tarix: ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine()).Date;
                        foreach (var item in _managment.GetOrderByDate(date))
                        {
                            Console.WriteLine(item.NormalShowInfo());
                        }
                        break;
                    case "7":
                        Console.WriteLine("axdarilan order no sunu daxil edin");
                        OredrNo = Metods.PositiveIntChecker("No: ", "Yalsniz reqem daxil edin");
                        while (Validators.OrderNoIsExist(OredrNo))
                        {
                            Console.WriteLine("Bu id movcud deyil veya duzgun daxil edilmeyib");
                            OredrNo = Metods.PositiveIntChecker("No: ", "Yalsniz reqem daxil edin");
                        }
                        Console.WriteLine(_managment.GetOrderByNo(OredrNo).NormalShowInfo());
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Eses menuya qayidilir");
                        break;
                    default:
                        break;
                } 
            } while (!exit);
        }
    }
}
