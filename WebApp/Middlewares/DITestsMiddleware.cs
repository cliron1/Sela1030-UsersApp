using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.DI;

namespace WebApp.Middlewares {
	public class DITestsMiddleware {
		private readonly RequestDelegate _next;

		private readonly IOperationTransient tr;
		private readonly IOperationSingleton sn;

		public DITestsMiddleware(RequestDelegate next,
				IOperationTransient tr,
				IOperationSingleton sn
			) {
			_next = next;
			this.tr = tr;
			this.sn = sn;
		}

		public async Task Invoke(HttpContext context, IOperationScoped sc) {
			var result = new {
				Transient = tr.Uid,
				Scoped = sc.Uid,
				Singleton = sn.Uid
			};

			//context.Response.Headers.Add("DI-Tests", result.ToString());
			context.Items.Add("DI-Tests", result);

			await _next(context);
		}
	}

	public static class DITestsMiddlewareExtensions {
		public static IApplicationBuilder UseDITests(this IApplicationBuilder app) {
			return app.UseMiddleware<DITestsMiddleware>();
		}
	}
}
