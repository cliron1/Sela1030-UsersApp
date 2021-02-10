using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UsersApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApp {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<MyContext>(opts =>
				opts.UseSqlServer(Configuration.GetConnectionString("Default"))
			);

			//services.AddSingleton<IUsersService, UsersServiceMemory>();
			services.AddScoped<IUsersService, UsersServiceSql>();

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.Use(async (context, next) => {
				var watch = Stopwatch.StartNew();

				context.Response.OnStarting(state => {
					var httpContext = (HttpContext)state;
					watch.Stop();
					httpContext.Response.Headers.Add("Duration", new[] { $"{watch.ElapsedMilliseconds} ms" });
					return Task.CompletedTask;
				}, context);

				await next.Invoke();

				//watch.Stop();
				//context.Response.Headers.Add("duration", $"{watch.ElapsedMilliseconds} ms");

			});

			//app.Run(async context => {
			//	Console.WriteLine("before");

			//	await context.Response.WriteAsync("Hello, World!");

			//	Console.WriteLine("after");
			//});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
