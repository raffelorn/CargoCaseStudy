using CargoCaseStudyAPI.Domain;
using CargoCaseStudyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoCaseStudyAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShippingSelectionRulesController : ControllerBase
	{
		private readonly AppDbContext context;

		public ShippingSelectionRulesController(AppDbContext context)
        {
			this.context = context;
		}

		[HttpGet("getAllShippingRules")]
		public async Task<IActionResult> Get()
		{
			return new JsonResult(await context.ShippingSelectionRules.AsNoTracking().ToListAsync());
		}
		[HttpGet("getByID/{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var cargo = await context.ShippingSelectionRules.FindAsync(id);
			if (cargo == null) return NotFound("Cargo does not exist.");
			return Ok(cargo);
		}
		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody] ShippingSelectionRulesViewModel model)
		{
			var shippingSelectionRule = ShippingSelectionRule.FromModel(model);
			context.ShippingSelectionRules.Add(shippingSelectionRule);
			await context.SaveChangesAsync();
			return Ok(shippingSelectionRule);

		}

		[HttpPut("edit/{id:int}")]
		public async Task<IActionResult> Edit(int id, [FromBody] ShippingSelectionRulesViewModel model)
		{
			var item = await context.ShippingSelectionRules.FindAsync(id);
			if (item == null) return NotFound("item not found");
			item.Cargo = model.Cargo;
			item.OrderNo = model.OrderNo;
			item.City = model.City;
			item.District	= model.District;

			context.ShippingSelectionRules.Update(item);
			await context.SaveChangesAsync();
			return Ok(item);
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var item = await context.ShippingSelectionRules.FindAsync(id);
			if (item == null) return NotFound("The item does not exist.");
			context.ShippingSelectionRules.Remove(item);
			await context.SaveChangesAsync();
			return Ok($"Item {item.Id} removed succesfully");

		}



	}
}
