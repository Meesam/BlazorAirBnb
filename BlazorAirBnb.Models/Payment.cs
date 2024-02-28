using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class Payment : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        [MaxLength(200)]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "Card number is required")]
        [MaxLength(200)]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Card holder name is required")]
        [MaxLength(255)]
        public string? CardHolderName { get; set; }

        [Required(ErrorMessage = "Card expiration date is required")]
        public DateTime ExpirationDate { get; set; }

        public string? UserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
    }
}
