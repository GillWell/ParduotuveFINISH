using eShop.Data.Base;
using eShop.Models;

namespace eShop.Data.Services
{
	public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
	{
		public CinemasService(AppDbContext context) : base(context) { }
	}
}
