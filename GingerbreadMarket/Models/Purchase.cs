using System;
using System.ComponentModel.DataAnnotations;

namespace GingerbreadMarket.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fulfilled { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string BuyerEmail { get; set; }
        public string SellerEmail { get; set; }
    }
}