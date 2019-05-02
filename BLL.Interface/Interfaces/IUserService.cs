using BLL.Interface.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
	public interface IUserService
	{
		Task RegisterUserAsync(User user);

		Task<User> FindByLoginAsync(string userName);

		Task<ClaimsIdentity> CreateClaimAsync(string userName, string password);
	}
}
