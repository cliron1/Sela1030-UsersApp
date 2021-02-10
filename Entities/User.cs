using System.Collections.Generic;

namespace Entities {
	public class User {
		public int Id { get; set; }

		public string Name { get; set; }

		public CustTypes TypeID { get; set; }

		public List<Contact> Contacts { get; set; }
	}

	public enum CustTypes {
		Company = 0,
		Private = 1
	}
}
