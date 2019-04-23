using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class Booking
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal Price { get; set; }
		public BookingStatus BookingStatus { get; set; }

		public Room Room { get; set; }
		public User User { get; set; }
	}
}
