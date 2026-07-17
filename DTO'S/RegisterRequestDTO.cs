using System.ComponentModel.DataAnnotations;

namespace LoginAuthAPI.DTO_S
{
    public class RegisterRequestDTO
    {

        //Required
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        //Required
        [EmailAddress]
        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        //Required
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
