using System.Web.Mvc;
using System.Linq;
using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace WebUI.Controllers
{
    using System;
    using System.Linq.Expressions;

    using Microsoft.Ajax.Utilities;

    public class RoomsController : Controller
    {
        private readonly IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public ActionResult FindRooms()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult FindRooms(FindRoomsRequest request)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = this.roomService.GetRooms(request);

            return this.View("RoomsBooking", model.ToList());
        }

        public ActionResult RoomsBooking()
        {
            var model = this.roomService.GetRooms();
            return View(model.ToList());
        }

        public ActionResult ControlRoomService()
        {
            var model = this.roomService.GetRooms();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult DeleteRoom(string id)
        {
            var model = this.roomService.GetRoom(int.Parse(id));
            return this.View(model);
        }

        [HttpPost]
        public ActionResult DeleteRoom(string id, FormCollection collection)
        {
            this.roomService.DeleteRoom(int.Parse(id));
            return this.RedirectToAction("ControlRoomService");
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateRoom(Room room)
        {
            this.roomService.AddRoom(room);
            return this.RedirectToAction("ControlRoomService");
        }

        [HttpGet]
        public ActionResult EditRoom(string id)
        {
            var model = this.roomService.GetRoom(int.Parse(id));
            return this.View(model);
        }

        [HttpPost]
        public ActionResult EditRoom(Room book)
        {
            this.roomService.UpdateRoom(book);

            return this.RedirectToAction("ControlRoomService");
        }

		[HttpGet]
		public ContentResult GetRooms()
		{
			var data = this.roomService.GetRooms();

			var json = JsonConvert.SerializeObject(data);

			return Content(json, "application/json");
		}
    }
}
