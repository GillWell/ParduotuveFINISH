using eShop.Data.Base;
using eShop.Models;

namespace eShop.Data.Services
{
	public class ProducersService:EntityBaseRepository<Producer>, IProducersService
	{
		public ProducersService(AppDbContext context) : base(context) { }
	}
}
