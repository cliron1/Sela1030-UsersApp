using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

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
