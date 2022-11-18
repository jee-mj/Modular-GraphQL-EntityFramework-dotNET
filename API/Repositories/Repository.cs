using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;
using Model;
using Database.Data;

namespace API.Repositories
{
    public class Repository : IRepository
    {
        public readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Restaurant>> GetAllRestaurants()
        {
            return _context.Restaurants.ToListAsync();
        }

        public Task<Restaurant> GetRestaurantById(Guid id)
        {
            return _context.Restaurants.SingleOrDefaultAsync(r => r.Id == id);
        }
    }
}
