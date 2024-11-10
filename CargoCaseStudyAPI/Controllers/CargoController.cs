using CargoCaseStudyAPI.Domain;
using CargoCaseStudyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoCaseStudyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : Controller
    {
        private readonly AppDbContext context;

        public CargoController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet("getAllCargo")]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(await context.CargoDefinitions.AsNoTracking().ToListAsync());
        }
        [HttpGet("getByID/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cargo = await context.CargoDefinitions.FindAsync(id);
            if (cargo == null) return NotFound("Cargo does not exist.");
            return Ok(cargo);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CargoDefinitionViewModel model)
        {
            var cargo = CargoDefinition.FromModel(model);

            context.CargoDefinitions.Add(cargo);
            await context.SaveChangesAsync();
            return Ok(cargo);

        }

        [HttpPut("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CargoDefinitionViewModel model)
        {
            var item = await context.CargoDefinitions.FindAsync(id);
            if (item == null) return NotFound("item not found");
            item.Cargo = model.Cargo;
            item.MaxWeight = model.MaxWeight;
            item.MinWeight = model.MinWeight;
            context.CargoDefinitions.Update(item);
            await context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await context.CargoDefinitions.FindAsync(id);
            if (item == null) return NotFound("The item does not exist.");
            context.CargoDefinitions.Remove(item);
            await context.SaveChangesAsync();
            return Ok($"Item {item.Id} removed succesfully");

        }
    }
}
