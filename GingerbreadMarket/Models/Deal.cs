using System;

namespace GingerbreadMarket.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public DateTime DealDate { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string BuyEmail { get; set; }
        public string SellEmail { get; set; }
    }
}
