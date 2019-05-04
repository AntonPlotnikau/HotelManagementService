using BLL.Interface.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Booking
	{
		public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
		public BookingStatus BookingStatus { get; set; }

		public Room Room { get; set; }
		public User User { get; set; }
	}
}
