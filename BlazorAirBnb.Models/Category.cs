using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class Category : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100)]
        [MinLength(5)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category type is required.")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Type { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
