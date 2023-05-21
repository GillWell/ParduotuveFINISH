using eShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
	public class Cinema:IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Display(Name ="Cinema Logo")]
		[Required(ErrorMessage ="Cinema logo is required")]
		public string Logo { get; set; }

		[Display(Name="Name")]
		[Required(ErrorMessage = "Cinema name is required")]
		public string Name { get; set; }

		[Display(Name="Discription")]
		public string Description { get; set; }
		//RelationShips
		public List<Movie> Movies { get; set; }
	}
}
