using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class ProductOrder : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public int CartId { get; set; }

        [JsonIgnore]
        public Cart? Cart { get; set; }
    }
}
