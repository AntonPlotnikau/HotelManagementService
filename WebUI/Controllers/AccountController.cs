using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using DAL.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
	public class AccountController : Controller
    {
		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private readonly IUserService service;

		public AccountController(IUserService service)
		{
			this.service = service;
		}

        public async Task<ActionResult> GetAccountInfo()
        {
            var user = await this.service.FindByLoginAsync(HttpContext.User.Identity.Name);
            return View(user);
        }

		public async Task<ActionResult> GetAccountInfoByName(string name)
		{
			var user = await this.service.FindByLoginAsync(name);
			return View("GetAccountInfo", user);
		}


		#region Регистрация
		[AllowAnonymous]
		// GET: Account
		public ActionResult Register()
        {
            return View();
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult> Register(User user)
		{
			try
			{
				await service.RegisterUserAsync(user);
			}
			catch (ArgumentException)
			{
				ModelState.AddModelError("UserName", "Логин уже используется");
			}

			if (ModelState.IsValid)
			{
				return RedirectToAction("Login");
			}

			return View(user);
		}
		#endregion

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl;
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(User model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var claim = await service.CreateClaimAsync(model.UserName, model.Password);
					AuthenticationManager.SignOut();
					AuthenticationManager.SignIn(new AuthenticationProperties
					{
						IsPersistent = true
					}, claim);
					if (string.IsNullOrEmpty(returnUrl))
						return RedirectToAction("Index", "Home");
					return Redirect(returnUrl);
				}
				catch (ArgumentException)
				{
					ModelState.AddModelError("", "Неверный логин или пароль.");
				}
			}
			ViewBag.returnUrl = returnUrl;
			return View(model);
		}

		[Authorize]
		public ActionResult Logout()
		{
			AuthenticationManager.SignOut();
			return RedirectToAction("Login");
		}
	}
}