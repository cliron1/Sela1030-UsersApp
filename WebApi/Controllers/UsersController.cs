using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers {
	[ApiController]
	[Route("api/users")]
	public class UsersController : Controller {
		private readonly MyContext context;

		public UsersController(MyContext context) {
			this.context = context;
		}

		[HttpGet]
		public IActionResult GetAll() {
			var data = context.Users.ToList();
			return Ok(data);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id) {
			if(id <= 0)
				return NotFound();
			var item = context.Users.FirstOrDefault(x => x.Id == id);
			if(item == null)
				return NotFound();
			return Ok(item);
		}
		[HttpPost]
		public IActionResult Add(User item) {
			context.Users.Add(item);
			context.SaveChanges();
			return StatusCode(201);
		}
		[HttpPut("{id}")]
		public IActionResult Add(int id, User item) {
			if(id <= 0)
				return NotFound();
			item.Id = id;
			context.Users.Update(item);
			context.SaveChanges();
			return StatusCode(202);
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var item = context.Users.FirstOrDefault(x => x.Id == id);
			context.Users.Remove(item);
			context.SaveChanges();
			return StatusCode(202);
		}
	}
}
