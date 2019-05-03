using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models.Enums
{
	public enum BookingStatus
	{
		[Display(Name = "Открыта")]
		Opened,
		[Display(Name = "Подтверждена")]
		Confirmed,
		[Display(Name = "Отклонена")]
		Declined,
		[Display(Name = "Отменена")]
		Closed
	}
}
