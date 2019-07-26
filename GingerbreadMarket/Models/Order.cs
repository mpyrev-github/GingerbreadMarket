using System.ComponentModel.DataAnnotations;

namespace GingerbreadMarket.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public bool IsSell { get; set; } // Order to sell or not
        public int Count { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }
    }
}