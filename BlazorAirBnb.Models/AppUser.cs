using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Dob is required")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public List<Contact> ContactsList { get; set; } = new List<Contact>();

        public List<Order> OrderList { get; set; } = new List<Order>();

        public List<WishList> WishLists { get; set; } = new List<WishList>();

        public List<Payment> PaymentList { get; set; } = new List<Payment>();
    }
}
