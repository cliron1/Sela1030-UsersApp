using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApp.Filters {
	public class SimpleActionFilter : ActionFilterAttribute {
		private string path = @"C:\code\1030\logs\log.txt";

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			string actionName = filterContext.ActionDescriptor.RouteValues["action"];

			using(FileStream fs = new FileStream(path, FileMode.Create)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine(actionName + " started");
				}
			}
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext) {
			string actionName = filterContext.ActionDescriptor.RouteValues["action"];

			using(FileStream fs = new FileStream(path, FileMode.Append)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine(actionName + " finished");
				}
			}
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext) {
			using(FileStream fs = new FileStream(path, FileMode.Append)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine("OnResultExecuting");
				}
			}
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext) {
			ContentResult result = (ContentResult)filterContext.Result;
			using(FileStream fs = new FileStream(path, FileMode.Append)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine("Result: " + result.Content);
				}
			}
		}
	}
}
