using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class UserInfo
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public Gender Sex { get; set; }

		public User User { get; set; }
	}
}
