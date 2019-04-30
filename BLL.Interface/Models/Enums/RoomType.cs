using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Models.Enums
{
    public enum RoomType
	{
        [Display(Name = "Стандартный ")]
        Single,
        [Display(Name = "Стандартный двухспальный")]
        Double,
		Twin,
		Studio,
		MiniSuite,
		Suite,
		PresidentSuite
	}
}
