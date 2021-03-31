using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Models;
using WebApp.DI;

namespace WebApp.Controllers {
	[Route("params")]
	public class ParamsController : Controller {
		[HttpGet("1")]
		public ActionResult One() {
			return Content("all good");
		}
		[HttpGet("2")]
		public ActionResult Two() {
			return Ok("all good");
		}
		[HttpGet("3")]
		public IActionResult Three() {
			return BadRequest();
		}

		[HttpGet("4")]
		public Person Four() {
			return new Person();
		}

		[HttpGet("5")]
		public ActionResult<Person> Five() {
			//return Ok();
			//return Content("all good?");
			return new Person { Name = "Testing5" };
			//return new ContactModel { FirstName = "Testing5" };
		}

		[HttpGet("6")]
		public JsonResult Six() {
			//return Ok();
			//return Content("{\"name\": \"liron\"}");
			return Json(new Person { Name = "Testing6" });
			//return new ContactModel { FirstName = "Testing" };
		}

		[HttpGet("adv/{id?}")]
		public IActionResult Adv(
			[FromRoute] int id,
			[FromQuery] string name,
			[FromQuery] int age,

			[FromHeader(Name = "Accept-Language")] string langs,
			[FromServices] IOperationSingleton op
		) {
			return Ok($"{id} => {name} is {age} YO; accept = {langs}; DI: {op.Uid}");
		}
	}
}
