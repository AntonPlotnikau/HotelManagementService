using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class Room
	{
		public int Id { get; set; }
		public int PlacesCount { get; set; }
		public decimal DayPrice { get; set; }
		public RoomType RoomType { get; set; }
		public string Description { get; set; }

		public Hotel Hotel { get; set; }

		public IEnumerable<Booking> Bookings { get; set; }
	}
}
