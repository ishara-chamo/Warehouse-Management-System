using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class User: IdentityUser// Inherit from IdentityUser
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Hashed password storage

        public string Role { get; set; } = "User";

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
