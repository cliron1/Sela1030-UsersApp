using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Services {
	public static class DbConfig {
		public static void AddDb(this IServiceCollection services, IConfiguration config) {
			services.AddDbContext<MyContext>(opts =>
				opts.UseSqlServer(config.GetConnectionString("Default"))
			);
		}
	}
}
