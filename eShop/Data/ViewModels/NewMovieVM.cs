using eShop.Data.Base;
using eShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Models
{
    public class NewMovieVM
	{
		public int Id { get; set; }

		[Display(Name = "Movie name")]
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Display(Name = "Movie description")]
		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }

		[Display(Name = "Movie price")]
		[Required(ErrorMessage = "Price is required")]
		public double Price { get; set; }

		[Display(Name = "Movie poster URL")]
		[Required(ErrorMessage = "Movie poster is requierd")]
		public string ImageURL { get; set; }

		[Display(Name = "Movie Start date")]
		[Required(ErrorMessage = "Start date is requierd")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Movie End date")]
		[Required(ErrorMessage = "End date is requierd")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Select a Movie category")]
		[Required(ErrorMessage = "Movie category is requierd")]
		public MovieCategory MovieCategory { get; set; }

		//Relationships

		[Display(Name = "Select actor(s)")]
		[Required(ErrorMessage = "Movie actor(S) is requierd")]
		public List<int> ActorIds { get; set; }

		[Display(Name = "Select Cinema")]
		[Required(ErrorMessage = "Cinema is requierd")]
		public int CinemaId { get; set; }

		[Display(Name = "Select Producer")]
		[Required(ErrorMessage = "Producer is requierd")]
		public int ProducerId { get; set; }
	}
}
