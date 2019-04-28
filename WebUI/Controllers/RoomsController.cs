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

        public ActionResult OneColumn()
        {
            var model = this.roomService.GetRooms();
            return View(model.ToList());
        }

        public ActionResult SingleItem()
        {
            return View();
        }
    }
}
