using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;

namespace WebApp.Controllers {
	[Route("person")]
	public class PersonController : Controller {
		[Route("")]
		public IActionResult Index() {
			var model = new Person();
			return View(model);
		}

		[HttpPost("get-name")]
		public IActionResult GetName(Person item) {
			return Ok($"{item.Name} is {item.Age} YO");
		}
	}
}
