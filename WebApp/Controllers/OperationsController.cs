using Microsoft.AspNetCore.Mvc;
using WebApp.DI;

namespace WebApp.Controllers {
	[Route("ops")]
	public class OperationsController : Controller {
		private readonly IOperationTransient tr;
		private readonly IOperationScoped sc;
		private readonly IOperationSingleton sn;

		public OperationsController(
				IOperationTransient tr,
				IOperationScoped sc,
				IOperationSingleton sn
			) {
			this.tr = tr;
			this.sc = sc;
			this.sn = sn;
		}

		[HttpGet]
		public IActionResult Index() {
			var result = new {

				fromMiddleware = HttpContext.Items["DI-Tests"],

				fromController = new {
					Transient = tr.Uid,
					Scoped = sc.Uid,
					Singleton = sn.Uid
				}
			};
			
			return Ok(result);
		}
	}
}
