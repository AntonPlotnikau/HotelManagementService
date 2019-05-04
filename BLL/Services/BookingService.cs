using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using BLL.Interface.Models.Enums;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class BookingService : IBookingService
	{
		private readonly IBookingRepository repository;

		public BookingService(IBookingRepository repository) => this.repository = repository;

		public void AddBooking(Booking booking, string userName)
		{
			if(booking.EndDate < booking.StartDate)
			{
				throw new ArgumentException();
			}
			var bookingDB = new DAL.Booking
			{
				StartDate = booking.StartDate,
				EndDate = booking.EndDate,
				BookingStatus = BookingStatus.Opened.ToString(),
				Room = new DAL.Room
				{
					Id = booking.Room.Id
				}
			};

			repository.AddBooking(bookingDB, userName);
		}

		public void ChangeStatus(BookingStatus newStatus, int id)
		{
			var booking = repository.GetBooking(id);

			booking.BookingStatus = newStatus.ToString();

			repository.UpdateBooking(booking);
		}

		public IEnumerable<Booking> GetAllBookings()
        {
            var bookingsDB = repository.GetAllBookings();

            foreach (var booking in bookingsDB)
            {
                yield return new Booking
                                 {
                                     Id = booking.Id,
                                     StartDate = booking.StartDate,
                                     EndDate = booking.EndDate,
                                     Price = booking.Price,
                                     BookingStatus =
                                         (BookingStatus)Enum.Parse(typeof(BookingStatus), booking.BookingStatus, true),
                                     User = new User { Id = booking.User.Id, UserName = booking.User.UserName },
                                     Room = new Room { Id = booking.Room.Id, ImageURL = booking.Room.ImageURL }
                                 };
            }
        }

		public Booking GetBooking(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Booking> GetBookings(string userName)
		{
			var bookingsDB = repository.GetBookings(userName);
			var bookings = new List<Booking>();
			foreach (var booking in bookingsDB)
			{
				bookings.Add(new Booking
				{
					Id = booking.Id,
					StartDate = booking.StartDate,
					EndDate = booking.EndDate,
					Price = booking.Price,
					BookingStatus = (BookingStatus)Enum.Parse(typeof(BookingStatus), booking.BookingStatus, true),
					User = new User
					{
						Id = booking.User.Id,
						UserName = booking.User.UserName
					},
					Room = new Room
					{
						Id = booking.Room.Id,
						ImageURL = booking.Room.ImageURL
					}
				});
			}

			return bookings;
		}

		public void UpdateBooking(Booking booking)
		{
			throw new NotImplementedException();
		}
	}
}
