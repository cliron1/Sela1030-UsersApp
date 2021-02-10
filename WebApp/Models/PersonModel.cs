namespace UsersApp.Models {
	public class Person {
		public string Name { get; set; }
		public int Age { get; set; }

		public bool IsAdult() {
			return Age >= 18;
		}
	}
}
