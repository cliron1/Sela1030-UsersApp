using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<MyContext>(opts =>
				opts.UseSqlServer(Configuration.GetConnectionString("Default"))
			);

			services.AddControllers();

			services.AddCors(options => {
				options.AddDefaultPolicy(
					builder => {
						builder.WithOrigins("http://localhost:5000")
						.AllowAnyHeader()
						.AllowAnyMethod();
					});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseCors();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
