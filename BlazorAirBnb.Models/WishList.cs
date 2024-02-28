using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class WishList : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wishlist name is required")]
        public string WishListName { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();

        public string? UserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
    }
}
