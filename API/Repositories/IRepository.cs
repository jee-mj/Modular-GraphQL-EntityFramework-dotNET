using Model;

namespace API.Repositories
{
    public interface IRepository
    {
        Task<List<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurantById(Guid id);
    }
}
