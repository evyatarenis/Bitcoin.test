using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bitcoin_Test.Models
{
    public class Order
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [DisplayName("User Name")]
        public string? UserName { get; set; }
        [DisplayName("Amount")]
        public decimal Amount { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Order Type")]
        public OrderType OrderType { get; set; }
    }
}
