using Entities;
using System.Collections.Generic;
using System.Linq;

namespace UsersApp.Services {
	public class UsersServiceMemory: IUsersService {
		private readonly List<User> data = new List<User>{
			new User{ Id=1, Name = "Liron"},
			new User{ Id=2, Name = "Tal"},
			new User{ Id=3, Name = "Naama"}
		};

		public List<User> GetAll() => data;

		public User GetById(int id) => data.FirstOrDefault(x => x.Id == id);

		public void Add(User model) {
			model.Id = data.Max(x => x.Id) + 1;
			data.Add(model);
		}

		public void Update(User model) {

		}
	}
}
