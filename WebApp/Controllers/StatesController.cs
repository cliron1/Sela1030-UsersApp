using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers {
	[Route("states")]
	public class StatesController : Controller {
		//public IActionResult Index() {
		//	//ViewData.Add("title", "ViewBag Sample");
		//	//ViewData.Add("MinAge", 18);

		//	ViewBag.Title = "ViewBag Sample";
		//	ViewBag.MinAge = 18;

		//	var model = new Person { Name = "ViewData & ViewBag"};
		//	return View(model);
		//}

		[HttpGet("temp-data")]
		public IActionResult TempDataTest(string arg) {
			TempData["msg"] = arg;
			return RedirectToAction("TempDataReuslt");
		}
		[HttpGet("temp-data-result")]
		public IActionResult TempDataReuslt() {
			return View();
		}

		[Route("qs")]
		public IActionResult QSTest(string arg) {
			// Note: QueryString send a value that can be used on the receiving end.
			var url = Url.Action("QSResult", new { msg = arg});
			return Redirect(url);
		}
		[Route("qs-result")]
		public IActionResult QSResult() {
			return View();
		}

		[Route("cookie")]
		public IActionResult CookieTest(string arg) {
			var options = new CookieOptions {
				Expires = DateTime.Now.AddSeconds(5)
			};
			HttpContext.Response.Cookies.Append("msg", arg, options);
			return RedirectToAction("CookieResult");
		}
		[Route("cookie-result")]
		public IActionResult CookieResult() {
			return View();
		}

		[Route("session")]
		public IActionResult SessionTest(string arg) {
			HttpContext.Session.SetString("msg", arg);
			return RedirectToAction("SessionResult");
		}
		[Route("session-result")]
		public IActionResult SessionResult() {
			return View();
		}
	}
}
