using Entities;
using System.Collections.Generic;

namespace UsersApp.Services {
	public interface IUsersService {
		List<User> GetAll();

		User GetById(int id);

		void Add(User model);

		void Update(User model);
	}
}
