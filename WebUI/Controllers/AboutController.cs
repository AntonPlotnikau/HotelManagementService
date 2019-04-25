using BLL.Interface.Interfaces;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
		private readonly IHotelService service;

		public AboutController(IHotelService service)
		{
			this.service = service;
		}

        public ActionResult Index()
        {
			var model = service.GetHotel();

			return View(model);
        }
	}
}