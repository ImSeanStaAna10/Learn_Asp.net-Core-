using HowToCreateWebAPI.Contracts;
using System.ComponentModel.DataAnnotations;

namespace HowToCreateWebAPI.Models
{
    public class User: IbaseModel
    {
        public int Id { get; set; }

        // Validation
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
