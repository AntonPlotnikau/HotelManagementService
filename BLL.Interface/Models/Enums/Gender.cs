using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Models.Enums
{
	public enum Gender
	{
		[Display(Name = "Мужчина")]
		Male,
		[Display(Name = "Женщина")]
		Female
	}
}
