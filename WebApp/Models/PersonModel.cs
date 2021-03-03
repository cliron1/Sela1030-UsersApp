using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models {
	public class Person {
		[Required(ErrorMessage = "Mandatory field")]
		[StringLength(20, ErrorMessage = "Maximum 20 chars")]
		public string Name { get; set; }

		[Range(1, 120, ErrorMessage = "A person can be 1 to 120 years old")]
		public int Age { get; set; }

		public bool IsAdult() {
			return Age >= 18;
		}
	}
}
