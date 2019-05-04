using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		public void AddBooking(Booking booking, string userName)
		{
			using (var container = new DataModelContainer())
			{
				bool isBooked = container.Rooms.FirstOrDefault(r => r.Id == booking.Room.Id).Bookings.Any(
					b => (b.BookingStatus == "Opened" || b.BookingStatus == "Confirmed") &&
				(booking.StartDate < b.StartDate && b.StartDate < booking.EndDate ||
				booking.StartDate < b.EndDate && b.EndDate <= booking.EndDate ||
				b.StartDate < booking.StartDate && b.EndDate > booking.EndDate));

				if (isBooked)
				{
					throw new ArgumentException();
				}

				var user = container.Users.FirstOrDefault(u => u.UserName == userName);
				var room = container.Rooms.FirstOrDefault(r => r.Id == booking.Room.Id);
				booking.User = user;
				booking.Room = room;
				booking.Price = booking.Room.DayPrice * (decimal)(booking.EndDate - booking.StartDate).TotalDays;
				container.Bookings.Add(booking);
				container.SaveChanges();
			}
		}

        public Booking GetBooking(int id)
		{
			using(var container = new DataModelContainer())
			{
				return container.Bookings.FirstOrDefault(b => b.Id == id);
			}
		}

		public IEnumerable<Booking> GetBookings(string userName)
		{
			using(var container = new DataModelContainer())
			{
				var bookings = container.Bookings.Where(b => b.User.UserName == userName).Include(b => b.Room).Include(b => b.User);

				return bookings.ToList();
			}
		}

        public IEnumerable<Booking> GetAllBookings()
        {
            using (var container = new DataModelContainer())
            {
                return container.Bookings.Include(x => x.Room).Include(x => x.User).ToList();
            }
        }

        public void UpdateBooking(Booking booking)
		{
			using(var container = new DataModelContainer())
			{
				var bookingDB = container.Bookings.FirstOrDefault(b => b.Id == booking.Id);

				bookingDB.Price = booking.Price;
				bookingDB.StartDate = booking.StartDate;
				bookingDB.EndDate = booking.EndDate;
				bookingDB.BookingStatus = booking.BookingStatus;
				container.SaveChanges();
			}
		}
	}
}
