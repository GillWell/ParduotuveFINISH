using eShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
	public class Actor:IEntityBase
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture is required")]
		public string ProfilePictureURL { get; set; }
		
		[Display(Name = "Full name")]
		[Required(ErrorMessage = "Full Name is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
		public string FullName { get; set; }

		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Biography is required")]
		public string Bio { get; set; }

		//RelationShips
		public List<Actor_Movie> Actors_Movies { get; set; }
	}
}
