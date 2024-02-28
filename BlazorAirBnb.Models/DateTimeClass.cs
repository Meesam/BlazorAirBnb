using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class DateTimeClass
    {
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string? CreatedBy { get; set; }

        [MaxLength(255)]
        public string? UpdatedBy { get; set; }
    }
}
