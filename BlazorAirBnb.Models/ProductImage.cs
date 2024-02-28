using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class ProductImage : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public string Title { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

    }
}
