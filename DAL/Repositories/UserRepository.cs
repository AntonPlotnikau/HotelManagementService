using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class UserRepository : IUserStore<User>
	{
		private readonly DataModelContainer container = new DataModelContainer();

		public Task CreateAsync(User user)
		{
			return Task.Factory.StartNew(() => container.Users.Add(user));
		}

		public Task DeleteAsync(User user)
		{
			return Task.Factory.StartNew(() =>
				{
					var userDB = container.Users.FirstOrDefault(u => u.Id == user.Id);
					container.Users.Remove(userDB);
				});
		}

		public void Dispose()
		{
			container.SaveChanges();
		}

		public Task<User> FindByIdAsync(string userId)
		{
			return Task<User>.Factory.StartNew(() => container.Users.FirstOrDefault(u => u.Id == userId));
		}

		public Task<User> FindByNameAsync(string userName)
		{
			return Task<User>.Factory.StartNew(() => container.Users.FirstOrDefault(u => u.UserName == userName));
		}

		public Task UpdateAsync(User user)
		{
			return Task.Factory.StartNew(() => 
			{
				var userDB = container.Users.FirstOrDefault(u => u.Id == user.Id);
				userDB.Password = user.Password;
				userDB.UserName = user.UserName;
				userDB.UserInfo.Name = user.UserInfo.Name;
				userDB.UserInfo.PhoneNumber = user.UserInfo.PhoneNumber;
				userDB.UserInfo.Email = user.UserInfo.Email;
				userDB.UserInfo.Surname = user.UserInfo.Surname;
				userDB.UserInfo.Sex = user.UserInfo.Sex;
				userDB.UserInfo.Age = user.UserInfo.Age;
			});
		}
	}
}
