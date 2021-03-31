using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models {
	public class Person {
		[Required(ErrorMessage = "Mandaory")]
		[RegularExpression("^[A-Za-z \\-]*$", ErrorMessage = "Text only")]
		[StringLength(20)]
		public string Name { get; set; }

		[Range(1, 120, ErrorMessage ="Person must be at least 1 YO")]
		public int Age { get; set; }

		public bool IsAdult() {
			return Age >= 18;
		}
	}
}