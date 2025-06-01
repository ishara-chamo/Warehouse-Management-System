using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class ApplicationUser: IdentityUser
    {


        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User"; // Default role
    }
}

