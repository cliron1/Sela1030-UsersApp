using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers {
	[Route("/states")]
	public class StatesController : Controller {
		[Route("qs")]
		public IActionResult QSTest(string arg) {
			// Note: QueryString send a value that can be used on the receiving end.
			TempData["msg"] = arg;
			//return RedirectToAction("TempDataResult",);
			return Redirect(Url.Action("QSResult", new { msg = arg }));
		}
		[Route("qs-result")]
		public IActionResult QSResult() {
			return View();
		}

		[Route("temp-data")]
		public IActionResult TempDataTest(string arg) {
			// Note: TempData stores a value in memory that can be used ONCE on the receiving end.
			TempData["msg"] = arg;
			return RedirectToAction("TempDataResult");
		}
		[Route("temp-data-result")]
		public IActionResult TempDataResult() {
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
	}
}
