using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
	public static class MenuSecurity
	{
		public static bool IsAuthorized
		{
			get
			{
				return HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated;
			}
		}

		public static bool IsManager
		{
			get
			{
				return IsAuthorized && HttpContext.Current.User.IsInRole("Manager");
			}
		}

		public static bool IsClient
		{
			get
			{
				return IsAuthorized && HttpContext.Current.User.IsInRole("Client");
			}
		}
	}
}