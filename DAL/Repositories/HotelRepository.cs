using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class HotelRepository : IHotelRepository
	{
		public Hotel GetHotel()
		{
			using(DataModelContainer container = new DataModelContainer())
			{
				var hotel = container.Hotels.FirstOrDefault();

				return hotel;
			}
		}
    }
}
