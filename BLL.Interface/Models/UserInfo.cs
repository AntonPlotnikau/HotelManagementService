using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class UserInfo
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$", ErrorMessage = "Неверно набран номер")]
		public string PhoneNumber { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[Range(1,100)]
		public int Age { get; set; }
		public Gender Sex { get; set; }

		public User User { get; set; }
	}
}
