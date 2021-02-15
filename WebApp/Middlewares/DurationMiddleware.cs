using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApp.Middlewares {
	public class DurationMiddleware {
		private readonly RequestDelegate next;

		public DurationMiddleware(RequestDelegate next) {
			this.next = next;
		}

		public async Task Invoke(HttpContext context) {
			var watch = Stopwatch.StartNew();

			context.Response.OnStarting(state => {
				var httpContext = (HttpContext)state;
				watch.Stop();
				httpContext.Response.Headers.Add("Duration-in-ms", new[] { $"{watch.ElapsedMilliseconds} ms" });
				return Task.CompletedTask;
			}, context);

			await next(context);
		}
	}
}
