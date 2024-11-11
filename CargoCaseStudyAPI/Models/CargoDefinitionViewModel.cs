using System.ComponentModel.DataAnnotations;

namespace CargoCaseStudyAPI.Models
{
    public class CargoDefinitionViewModel:IValidatableObject
	{
        [Required(ErrorMessage = "Cargo is required.")]
        public string Cargo { get; set; }   
        [Required(ErrorMessage = "Min Weight is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Min Weight must be a positive number.")]
        public float MinWeight { get; set; }
        [Required(ErrorMessage = "Max Weight is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Max Weight must be a positive number.")]
        public float MaxWeight { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinWeight > MaxWeight)
            {
                yield return new ValidationResult(
                    "Min Weight cannot be greater than Max Weight.",
                    new[] { nameof(MinWeight), nameof(MaxWeight) });
            }
        }
    }
}

