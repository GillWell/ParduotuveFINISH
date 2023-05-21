using eShop.Data.Base;
using eShop.Data.ViewModels;
using eShop.Models;

namespace eShop.Data.Services
{
	public interface IMoviesService:IEntityBaseRepository<Movie>
	{
		Task<Movie> GetMovieByIdAsync(int id);
		Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
		Task AddNewMovieAsync(NewMovieVM data);
		Task UpdateMovieAsync(NewMovieVM data);
	}
}
