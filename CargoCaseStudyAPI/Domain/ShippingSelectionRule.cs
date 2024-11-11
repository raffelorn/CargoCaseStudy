using CargoCaseStudyAPI.Models;
using System.Runtime.CompilerServices;

namespace CargoCaseStudyAPI.Domain
{
    public class ShippingSelectionRule
    {
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public int OrderNo { get; set; }
        public string Cargo { get; set; } = null!;

        public static ShippingSelectionRule FromModel(ShippingSelectionRulesViewModel model)
        {
            return new ShippingSelectionRule
            {
                Cargo = model.Cargo,
                District = model.District,
                OrderNo = model.OrderNo,
                City = model.City,
            };
        }
    }
}
