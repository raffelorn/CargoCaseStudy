using CargoCaseStudyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoCaseStudyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicController : ControllerBase
    {
        private readonly AppDbContext context;

        public LogicController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost("Filter")]
        public async Task<IActionResult> Filter([FromBody] FilterViewModel model)
        {
            var query = from rule in context.ShippingSelectionRules
                        join cargoDef in context.CargoDefinitions
                        on rule.Cargo equals cargoDef.Cargo
                        where rule.City == model.City
                              && rule.District == model.District
                              && cargoDef.MinWeight <= model.Weight
                              && cargoDef.MaxWeight >= model.Weight
                        select new
                        {
                          
                            rule.OrderNo,
                            rule.Cargo,
                            
                        };

            var result = await query.ToListAsync();

            return Ok(result);
        }


    }
}
