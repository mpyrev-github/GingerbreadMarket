using System;

namespace GingerbreadMarket.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Email { get; set; }
        public bool IsSell { get; set; }
        public DateTime Date { get; set; }
    }
}
