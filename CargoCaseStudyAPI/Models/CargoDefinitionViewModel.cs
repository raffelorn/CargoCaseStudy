namespace CargoCaseStudyAPI.Models
{
    public class CargoDefinitionViewModel
    {
        public string Cargo { get; set; } = null!;
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
    }
}

