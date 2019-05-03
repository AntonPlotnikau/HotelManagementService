using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    using BLL.Interface.Models;

    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult BookRoom(string roomid)
        {
            ViewBag.roomid = int.Parse(roomid);
            //ViewBag["roomid"] = roomid;
            return View();
        }

        [HttpPost]
        public ActionResult BookRoom(Booking booking)
        {
            return View();
        }
    }
}