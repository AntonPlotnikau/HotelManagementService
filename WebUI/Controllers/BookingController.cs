using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
	using BLL.Interface.Interfaces;
	using BLL.Interface.Models;

    public class BookingController : Controller
    {
		private readonly IBookingService service;

		public BookingController(IBookingService service)
		{
			this.service = service;
		}

        public ActionResult BookRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookRoom(Booking booking)
        {
			try
			{
				booking.Room = new Room { Id = 1 }; // ??????????????????????????????????????????????????
				service.AddBooking(booking, HttpContext.User.Identity.Name);
			}
			catch (ArgumentException)
			{
				ModelState.AddModelError("", "Данные даты уже заняты либо диапазон дат неверен");
			}

			if (!ModelState.IsValid)
			{
				return View(booking);
			}

			return RedirectToAction("GetBookings");
		}

		public ActionResult GetBookings()
		{
			var model = this.service.GetBookings(HttpContext.User.Identity.Name);
			return View(model);
		}

        public ActionResult GetAllBookings()
        {
            var model = this.service.GetAllBookings();
            return View(model);
        }
	}
}