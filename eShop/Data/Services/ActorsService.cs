using eShop.Data.Base;
using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) : base(context) { }
    }
}
