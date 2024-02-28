using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class Order : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderStatus { get; set; } = string.Empty;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.MinValue;

        [MaxLength(200)]
        public string? PaymentMethod { get; set; }

        [MaxLength(100)]
        public string? PaymentStatus { get; set; }
    }
}
