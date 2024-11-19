using CargoCaseStudyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;

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

    //model.GetType().GetProperties().
    //Where(p=>level.GetType().GetProperties().Any(q=>q.Name == p.Name))
    //.ToList()
    //.ForEach(p=>level.GetType().GetProperty(p.Name)
    //.SetValue(level, model.GetType().GetProperty(p.Name).GetValue(model)));
}
