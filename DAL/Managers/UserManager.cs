using System;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL.Managers
{
	public class UserManager : UserManager<User>
	{
		public UserManager(IUserStore<User> store) : base(store)
		{
		}

		public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
		{
			UserManager manager = new UserManager(new UserRepository());
			return manager;
		}

		public async Task CreateUserAsync(User user)
		{
			using (Store)
			{
				var userDB = await Store.FindByNameAsync(user.UserName);

				if (userDB != null) 
				{
					throw new ArgumentException();
				}

				await Store.CreateAsync(user);
			}
		}

		public async Task<User> FindUserByNameAsync(string userName)
		{
			using (Store)
			{
				var userDB = await Store.FindByNameAsync(userName);

				return userDB;
			}
		}

		public override async Task<bool> IsInRoleAsync(string userId, string role)
		{
			using (Store)
			{
				var user = await Store.FindByIdAsync(userId);

				bool isInRole = user.UserRole == role;

				return isInRole;
			}
		}
	}
}
