using Entities;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace UsersApp.Services {
	public class UsersServiceSql: IUsersService {
		private MyContext context;

		public UsersServiceSql(MyContext context) {
			this.context = context;

			//context.Database.EnsureDeleted();
			//context.Database.EnsureCreated();
		}

		public List<User> GetAll() {
			var items = context.Users.ToList();
			return items;
		}

		public void Add(User model) {
			context.Users.Add(model);
			context.SaveChanges();
		}

		public User GetById(int id) {
			//var item = context.Users.FirstOrDefault(x=>x.Id == id);
			var item = context.Users.Find(id);
			return item;
		}

		public void Update(User model) {
			if(model.Id <= 0)
				return;
			context.Users.Update(model);
			context.SaveChanges();
		}
	}
}
