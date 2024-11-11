using System.ComponentModel.DataAnnotations;

namespace CargoCaseStudyAPI.Models
{
	public class ShippingSelectionRulesViewModel
	{
        [Required(ErrorMessage = "Cargo is required.")]
        public string Cargo { get; set; } = null!;

        [Required(ErrorMessage = "OrderNo is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "OrderNo must be a positive integer.")]
        public int OrderNo { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "District is required.")]
        public string District { get; set; } = null!;

    }
}
