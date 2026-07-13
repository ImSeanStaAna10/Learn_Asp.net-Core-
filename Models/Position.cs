using HowToCreateWebAPI.Contracts;
using System.ComponentModel.DataAnnotations;

namespace HowToCreateWebAPI.Models
{
    public class Position : IbaseModel
    {

        public int Id { get; set; }

        // Validation
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =  true)]
        public string Description { get; set; }
    }
}
