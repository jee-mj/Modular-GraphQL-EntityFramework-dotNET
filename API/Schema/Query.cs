using API.Repositories;
using API.Type;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;

namespace API.Schema
{
    public class Query : ObjectGraphType
    {
        public Query(IRepository repository, IDataLoaderContextAccessor accessor)
        {
            var loader = accessor.Context;
            Name = "Query";

            Field<RestaurantType>("restaurant")
                .Argument<NonNullGraphType<StringGraphType>>("id", "the restaurant identifier")
                .ResolveAsync(async context => await repository.GetRestaurantById(context.GetArgument<Guid>("id")).ConfigureAwait(false));
                
            Field<ListGraphType<RestaurantType>>("restaurants")
                .ResolveAsync(async context =>
                {
                    return loader?.GetOrAddLoader("GetAllRestaurants", repository.GetAllRestaurants);
                });
        }
    }
}
