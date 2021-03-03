using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApp.Filters {
	public class SimpleActionFilter : ActionFilterAttribute {
		private string path = @"C:\code\1030\logs\log.txt";

		private void log(string msg) {
			var mode = File.Exists(path)
				? FileMode.Append
				: FileMode.Create;
			using(FileStream fs = new FileStream(path, mode)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine(msg);
				}
			}
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			if(File.Exists(path))
				File.Delete(path);

			string actionName = filterContext.ActionDescriptor.RouteValues["action"];
			log(actionName + " started");
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext) {
			string actionName = filterContext.ActionDescriptor.RouteValues["action"];
			log(actionName + " finished");
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext) {
			log("OnResultExecuting");
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext) {
			var result = (ViewResult)filterContext.Result;
			log("Result: " + result.ViewName);
		}
	}
}
