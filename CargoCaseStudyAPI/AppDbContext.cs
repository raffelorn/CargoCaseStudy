using CargoCaseStudyAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CargoCaseStudyAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShippingSelectionRule> ShippingSelectionRules { get; set; }
        public DbSet<CargoDefinition> CargoDefinitions { get; set; }
    }
}
