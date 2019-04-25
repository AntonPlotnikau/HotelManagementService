using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using DAL.Interfaces;

namespace BLL.Services
{
	/// <summary>
	/// hotel service
	/// </summary>
	public class HotelService : IHotelService
	{
		private readonly IHotelRepository hotelRepository;

		public HotelService(IHotelRepository hotelRepository)
		{
			this.hotelRepository = hotelRepository;
		}

		public Hotel GetHotel()
		{
			var hotelDB = hotelRepository.GetHotel();

			return new Hotel
			{
				Id = hotelDB.Id,
				Description = hotelDB.Description,
				Name = hotelDB.Name,
				PhoneNumber = hotelDB.PhoneNumber,
				Address = hotelDB.Address
			};
		}
	}
}
