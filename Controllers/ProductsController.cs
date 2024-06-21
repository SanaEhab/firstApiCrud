using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task1.Models;

namespace task1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		List <Products> products = new List<Products>
		{
			new Products { Id = 1,Name="Laptop",Description="this is laptop"},
			new Products { Id = 2,Name="Desktop",Description="this is Desktop"},
			new Products { Id = 3,Name="Printer",Description="this is Printer"},
			new Products { Id = 4,Name="HeadPhone",Description="this is HeadPhone"},

		};

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(products);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id) { 

			var product = products.First(p => p.Id == id);

			if(product == null)
				return NotFound();

			return Ok(product);

		}

		[HttpPost]

		public IActionResult Add(Products request)
		{
			if (request == null)
				return BadRequest();

			var product = new Products
			{
				Id = request.Id,
				Name = request.Name,
				Description = request.Description,
			};
			products.Add(product);
			return Ok(products);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id,Products request) { 
			var product = products.FirstOrDefault(p => p.Id == id);
			if(product == null)
				return BadRequest();

			product.Name = request.Name;
			product.Description = request.Description;

			return Ok(product);
		}

		[HttpDelete("{id}")]

		public IActionResult Delete(int id) {
			var product = products.FirstOrDefault(p => p.Id == id);
			if(product == null)
				return NotFound();

			products.Remove(product);
			return Ok(products);
		}
	}
}
