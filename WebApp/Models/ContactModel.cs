using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models {
	public class ContactModel {
		[Required(ErrorMessage ="שדה חובה")]
		public string FirstName { get; set; }

		[Required(ErrorMessage ="requierd")]
		public string LastName { get; set; }

		[Required(ErrorMessage ="שדה חובה")]
		[EmailAddress(ErrorMessage = "כתובת לא חוקית")]
		public string Email { get; set; }
	}
}
