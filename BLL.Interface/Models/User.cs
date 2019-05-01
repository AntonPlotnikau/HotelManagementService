using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class User
	{
		public string Id { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public UserRole Role { get; set; }

		public UserInfo Info { get; set; }

		public IEnumerable<Booking> Bookings { get; set; }
	} 
}
