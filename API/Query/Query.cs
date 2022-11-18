using API.Repositories;
using API.Type;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Model;

namespace API.Query
{
    public class Query : ObjectGraphType
    {
        public Query(IDataLoaderContextAccessor accessor)
        {
            Name = "Query";

            Field<OwnerType, Owner>("owner")
                .Argument<NonNullGraphType<GuidGraphType>>("id", "the owner identifier")
                .Resolve()
                .WithService<IRepository>()
                .ResolveAsync(async (context, repository) =>
                {
                    return repository.GetOwnerById(context.GetArgument<Guid>("id"));
                });

            Field<ListGraphType<OwnerType>, List<Owner>>("owners")
                .Resolve()
                .WithService<IRepository>()
                .ResolveAsync(async (context, repository) =>
                {
                    return repository.GetAllOwners();
                });

            Field<RestaurantType, Restaurant>("restaurant")
                .Argument<NonNullGraphType<GuidGraphType>>("id", "the owner identifier")
                .Resolve()
                .WithService<IRepository>()
                .ResolveAsync(async (context, repository) =>
                {
                    return repository.GetRestaurantById(context.GetArgument<Guid>("id"));
                });

            Field<ListGraphType<RestaurantType>, List<Restaurant>>("restaurants")
                .Resolve()
                .WithService<IRepository>()
                .ResolveAsync(async (context, repository) =>
                {

                    return repository.GetAllRestaurants();
                });
        }
    }
}
