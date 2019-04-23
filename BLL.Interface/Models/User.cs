using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public UserRole UserRole { get; set; }

		public UserInfo Info { get; set; }

		public IEnumerable<Booking> Bookings { get; set; }
	} 
}
