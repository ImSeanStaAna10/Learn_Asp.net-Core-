using HowToCreateWebAPI.Contracts;
using System.ComponentModel.DataAnnotations;

namespace HowToCreateWebAPI.Models
{
    public class Hero : IbaseModel, IValidatableObject // another way of validating object
    {
        public int Id { get; set; }

        // Validation
        [Required(ErrorMessage = "Hero Name Required")]
        public string Name { get; set; }

        [Required, Range(18, 100)]
        public int Age { get; set; }


        //CUSTOM VALIDATION using IvalidateObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Age % 2 != 0)
            {
                yield return new ValidationResult("Even number only");
            }

            if(Name.Equals("HAHA", StringComparison.OrdinalIgnoreCase))
            {
                yield return new ValidationResult("NOT A NAME");
            }
        }






    }
}
