using BLL.Interface.Models;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
	public interface IBookingService
	{
		Booking GetBooking(int id);

		IEnumerable<Booking> GetAllBookings();

		IEnumerable<Booking> GetBookings(string userName);

        void AddBooking(Booking booking, string userName);

		void UpdateBooking(Booking booking);
	}
}
