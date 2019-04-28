using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Models.Enums
{
	public enum RoomType
	{
		[EnumMember(Value = "Стандартная односпальная")]
		Single,
		[EnumMember(Value = "Стандартная двухспальная")]
		Double,
		[EnumMember(Value = "Стандртная двухместная")]
		Twin,
		[EnumMember(Value = "Студия")]
		Studio,
		[EnumMember(Value = "Полулюкс")]
		MiniSuite,
		[EnumMember(Value = "Люкс")]
		Suite,
		[EnumMember(Value = "Президентский люкс")]
		PresidentSuite
	}
}
