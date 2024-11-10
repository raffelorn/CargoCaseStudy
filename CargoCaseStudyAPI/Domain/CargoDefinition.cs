using CargoCaseStudyAPI.Models;

namespace CargoCaseStudyAPI.Domain
{
	public class CargoDefinition
	{
		public int Id { get; set; }
		public string Cargo { get; set; } = null!;
		public float MinWeight { get; set; }
		public float MaxWeight { get; set; }
		public static CargoDefinition FromModel(CargoDefinitionViewModel model)
		{
			return new CargoDefinition { Cargo = model.Cargo, MinWeight = model.MinWeight, MaxWeight = model.MaxWeight };
		}
	}

}
