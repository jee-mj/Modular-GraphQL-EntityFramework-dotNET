using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Model;
using API.Data;

namespace API.Repositories
{
    public class Repository : IRepository
    {
        public readonly AppDbContext _context;
        public List<Owner> owners = new List<Owner>();
        public List<Restaurant> restaurants = new List<Restaurant>();

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        
        public List<Restaurant> GetAllRestaurants()
        {
            foreach (var restaurant in _context.Restaurants)
            {
                restaurant.Owner = _context.Owners.Where(o => o.Id == restaurant.OwnerId).Single();
                restaurants.Add(restaurant);
            }
            return restaurants;
        }
        public Restaurant GetRestaurantById(Guid id)
        {
            return GetAllRestaurants().SingleOrDefault(r => r.Id == id);
        }
        public List<Owner> GetAllOwners()
        {
            foreach (var owner in _context.Owners)
            {
                owner.Restaurants = _context.Restaurants.Where(r => r.OwnerId == owner.Id).ToList();
                owners.Add(owner);
            }
            return owners;
        }
        public Owner GetOwnerById(Guid id)
        {
            return GetAllOwners().SingleOrDefault(r => r.Id == id);
        }
    }

    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(Guid id);
        List<Owner> GetAllOwners();
        Owner GetOwnerById(Guid id);
    }
}
