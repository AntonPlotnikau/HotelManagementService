using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using BLL.Interface.Models.Enums;
using DAL.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BLL.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager manager;

		public UserService()
		{
			manager = HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();
		}

		public async Task<ClaimsIdentity> CreateClaimAsync(string userName, string password)
		{
			var user = await manager.FindUserByNameAsync(userName);
			if(user == null)
			{
				throw new ArgumentException();
			}

			if(user.Password != password)
			{
				throw new ArgumentException();
			}

			var claim = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			claim.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
			return claim;
		}

		public async Task<User> FindByLoginAsync(string userName)
		{
			var userDB = await manager.FindUserByNameAsync(userName);

			if(userDB == null)
			{
				throw new ArgumentException();
			}

			var info = new UserInfo
			{
				Name = userDB.UserInfo.Name,
				PhoneNumber = userDB.UserInfo.PhoneNumber,
				Email = userDB.UserInfo.Email,
				Surname = userDB.UserInfo.Surname,
				Sex = (Gender)Enum.Parse(typeof(Gender), userDB.UserInfo.Sex, true),
				Age = userDB.UserInfo.Age
			};

			var user = new User
			{
				Id = userDB.Id,
				UserName = userDB.UserName,
				Password = userDB.Password,
				Info = info,
				Role = (UserRole)Enum.Parse(typeof(UserRole), userDB.UserRole, true)
			};

			return user;
		}

		public async Task RegisterUserAsync(User user)
		{
			var info = new DAL.UserInfo
			{
				Name = user.Info.Name,
				PhoneNumber = user.Info.PhoneNumber,
				Email = user.Info.Email,
				Surname = user.Info.Surname,
				Sex = user.Info.Sex.ToString(),
				Age = user.Info.Age
			};

			var userDB = new DAL.User()
			{
				Password = user.Password,
				UserName = user.UserName,
				UserRole = UserRole.Client.ToString()
			};

			userDB.UserInfo = info;

			await manager.CreateUserAsync(userDB);
		}
	}
}
