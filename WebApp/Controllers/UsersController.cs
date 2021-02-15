using Microsoft.AspNetCore.Mvc;
using Entities;
using UsersApp.Services;

namespace UsersApp.Controllers {
	public class UsersController : Controller {
		private IUsersService service;

		public UsersController(IUsersService service) {
			this.service = service;
		}

		public IActionResult Index() {
			return View(service.GetAll());
		}

		public IActionResult Details(int id) {
			var model = service.GetById(id);
			if(model == null)
				return NotFound();
			return Ok(model);
		}
		[HttpPost]
		public IActionResult Save(User model) {
			service.Update(model);
			return Ok();
		}

		public IActionResult Add() {
			var item = new User();
			return View(item);
		}
		[HttpPost]
		public IActionResult Add(User model) {
			service.Add(model);
			return RedirectToAction("Index");
		}
	}
}
