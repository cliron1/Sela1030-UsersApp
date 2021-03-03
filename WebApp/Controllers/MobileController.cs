using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {
	[Route("mobile")]
	public class MobileController : Controller {
		
		public IActionResult Index() {
			return View();
		}
	}
}
