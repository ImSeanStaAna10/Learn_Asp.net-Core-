using System.ComponentModel.DataAnnotations;

namespace LoginAuthAPI.DTO_S
{
    public class LoginRequestDTO
    {

        //Required

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
