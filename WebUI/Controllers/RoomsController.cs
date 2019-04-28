using System.Web.Mvc;
using System.Linq;
using BLL.Interface.Interfaces;
using BLL.Interface.Models;

namespace WebUI.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
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

        //[HttpPost]
        //public ActionResult Delete(string isbn, FormCollection collection)
        //{
        //    try
        //    {
        //        this.service.Remove(isbn);

        //        return this.RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        ViewBag.Error = "This book is not kept!";
        //        return this.View();
        //    }
        //}
        //public ActionResult Details(string isbn)
        //{
        //    var findBook = this.service.FindByTag(isbn);

        //    return this.View(findBook);
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return this.View();
        //}

        //[HttpPost]
        //public ActionResult Create(Book book)
        //{
        //    try
        //    {
        //        this.service.Add(book);

        //        return this.RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        ViewBag.Error = "This book already saved!";
        //        return this.View();
        //    }
        //}

        public ActionResult SingleItem()
        {
            return View();
        }
    }
}
