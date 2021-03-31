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

			services
				.AddControllersWithViews()
				.AddJsonOptions(opts => {
					opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					opts.JsonSerializerOptions.WriteIndented = true;

				});

			services.AddSession(options => {
				options.IdleTimeout = TimeSpan.FromSeconds(20);
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

			app.UseMiddleware<DurationMiddleware>();
			//app.UseMiddleware<DITestsMiddleware>();
			app.UseDITests();

			app.UseSession();

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
