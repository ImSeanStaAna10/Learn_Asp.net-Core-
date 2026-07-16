using System.ComponentModel.DataAnnotations;

namespace LoginAuthAPI.Entities
{
    public class User
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Required
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        // Required
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        // Required
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Required
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "User";
    }
}