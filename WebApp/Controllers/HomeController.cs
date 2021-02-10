using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace UsersApp.Controllers {
	public class HomeController: Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() { // Action
			return View();
		}

		public IActionResult Privacy() { // Action
										  // Optional: Build Model

			//return View("/Views/Home/TermsOfUse.cshtml");
			return View();
		}

		public IActionResult People() { // Action
										//var age = 21;
										//var person = new Person{ Name="Sagi", Age=21 };
										//var person = new Person{ Name="Guy", Age=20 };
			var model = new List<Person>{
				new Person{ Name="Sagi", Age=21 },
				new Person{ Name="Guy", Age=17 }
			};

			return View(model);
		}

		public IActionResult RegistrationForm() {
			return View();
		}

		//[HttpPost]
		//public IActionResult RegistrationForm(
		//	string personalEmail, 
		//	string firstname, 
		//	string lastname) {
		//	var item = new { personalEmail, firstname, lastname };
		//	return Ok(item);
		//}

		[HttpPost]
		public IActionResult RegistrationForm(ContactModel model) {
			return Ok(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			var model = new ErrorViewModel {
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			};
			return View(model);
		}
	}
}
