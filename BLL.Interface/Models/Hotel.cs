using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
	public class Hotel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }

		public IEnumerable<Room> Rooms { get; set; }
	}
}
