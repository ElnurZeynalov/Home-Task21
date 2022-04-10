using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart
{
    public class Order
    {
        public static int _no;
        public int No { get; }
        public static List<MenuItem> OrderItems { get; set; }
        private DateTime _date;
        public DateTime Date { get; }
        public double TotalAmount { get; set; }
        
        public Order()
        {
            _no++;
            No = _no;
            OrderItems = new List<MenuItem>();
            _date = DateTime.Now;
            Date = _date;
        }
        public string NormalShowInfo()
        {
            return $"No: {this.No} - Date: {this.Date} - TotalAmount {this.TotalAmount}";
        }
        public void LargeShowInfo()
        {
            Console.WriteLine($"No: {this.No} - Date: {this.Date} - TotalAmount {this.TotalAmount}");
            foreach (var item in OrderItems)
            {
                Console.WriteLine(item.ShowInfo());
            }
        }
    }
}
