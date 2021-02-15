using Microsoft.AspNetCore.Mvc;
using Entities;
using UsersApp.Services;

namespace UsersApp.Controllers {
		[Route("users")]
	public class UsersController : Controller {
		private IUsersService service;

		public UsersController(IUsersService service) {
			this.service = service;
		}

		[HttpGet]
		public IActionResult Index() {
			return View(service.GetAll());
		}

		[HttpGet("{id}")]
		public IActionResult Details(int id) {
			var model = service.GetById(id);
			if(model == null)
				return NotFound();
			return Ok(model);
		}
		[HttpPost("{id}")]
		public IActionResult Save(User model) {
			service.Update(model);
			return Ok();
		}

		[HttpGet("new")]
		public IActionResult Add() {
			var item = new User();
			return View(item);
		}
		[HttpPost("new")]
		public IActionResult Add(User model) {
			service.Add(model);
			return RedirectToAction("Index");
		}
	}
}
