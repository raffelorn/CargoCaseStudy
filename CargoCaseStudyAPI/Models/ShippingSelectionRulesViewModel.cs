namespace CargoCaseStudyAPI.Models
{
	public class ShippingSelectionRulesViewModel
	{
		public string City { get; set; } = null!;
		public string District { get; set; } = null!;
		public int OrderNo { get; set; }
		public string Cargo { get; set; } = null!;
	}
}
