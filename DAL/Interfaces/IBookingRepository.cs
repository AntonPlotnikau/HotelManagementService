using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IBookingRepository
	{
		Booking GetBooking(int id);

		IEnumerable<Booking> GetAllBookings();

		IEnumerable<Booking> GetBookings(string userName);

        void AddBooking(Booking booking, string userName);

		void UpdateBooking(Booking booking);
	}
}
