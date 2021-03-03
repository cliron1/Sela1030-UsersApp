using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json;
using UsersApp.Services;
using WebApp.DI;
using WebApp.Middlewares;
using WebApp.Services;

namespace UsersApp {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddDb(Configuration);

			//services.AddSingleton<IUsersService, UsersServiceMemory>();
			services.AddScoped<IUsersService, UsersServiceSql>();

			services.AddSingleton<IOperationSingleton, Operation>();
			services.AddScoped<IOperationScoped, Operation>();
			services.AddTransient<IOperationTransient, Operation>();

			services.AddControllersWithViews()
				.AddJsonOptions(options => {
					// Use null for Pascal casing.
					options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					options.JsonSerializerOptions.WriteIndented = true;
				});
			;

			//services.Configure<CookiePolicyOptions>(options => {
			//	options.CheckConsentNeeded = context => true;
			//	options.MinimumSameSitePolicy = SameSiteMode.None;
			//});

			services.AddSession(options => {
				options.IdleTimeout = TimeSpan.FromMinutes(20);
				//options.Cookie.IsEssential = true;
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseStaticFiles(new StaticFileOptions {
				FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")
			),
				RequestPath = "/node_modules"
			});

			app.UseSession();

			app.UseMiddleware<DurationMiddleware>();
			//app.UseMiddleware<DITestsMiddleware>();
			app.UseDITests();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();

				//endpoints.MapControllerRoute(
				//	name: "default",
				//	pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
