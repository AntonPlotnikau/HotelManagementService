using BLL.Interface.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Room
	{
		public int Id { get; set; }

        [Range(1, 20, ErrorMessage = "Количество мест от 1 до 20")]
		public int PlacesCount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Цена не может быть отрицательной")]
		public decimal DayPrice { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public RoomType RoomType { get; set; }
		public string Description { get; set; }

        [RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)", ErrorMessage = "Некорректный URL изображения")]
        public string ImageURL { get; set; }

		public Hotel Hotel { get; set; }

		public IEnumerable<Booking> Bookings { get; set; }
	}
}
