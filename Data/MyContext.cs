using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data {
	public class MyContext: DbContext {
		public MyContext(DbContextOptions<MyContext> options)
			: base(options) {
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		//	var connString = "Server=.; Database=UsersDB; Trusted_Connection=True";
		//	optionsBuilder.UseSqlServer(connString);
		//	//base.OnConfiguring(optionsBuilder);
		//}
	}
}
