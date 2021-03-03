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
		[Route("1")]
		public ActionResult One() {
			return Content("all good");
		}
		[Route("2")]
		public ActionResult Two() {
			return Ok("all good");
		}
		[Route("3")]
		public IActionResult Three() {
			return BadRequest();
		}
		[Route("4")]
		public Person Four() {
			//return BadRequest();
			return new Person { Name = "Testing4" };
		}

		[Route("5")]
		public ActionResult<Person> Five() {
			return Ok();
			//return Content("all good?");
			//return new Person { Name = "Testing"};
			//return new ContactModel { FirstName = "Testing5" };
		}

		[Route("6")]
		public JsonResult Six() {
			//return Ok();
			//return Content("all good?");
			return Json(new Person { Name = "Testing6" });
			//return new ContactModel { FirstName = "Testing" };
		}

		[Route("adv/{id?}")]
		public IActionResult Adv([FromRoute]int id, [FromServices] IOperationSingleton operation, [FromHeader] string accept) {
			return Ok(id);
			//return Ok(operation.Uid);
			//return Ok(accept);
		}
	}
}
