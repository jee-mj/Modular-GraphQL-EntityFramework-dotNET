using API.Data;
using API.Repositories;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Model;

namespace API.Type
{
    public class RestaurantType : ObjectGraphType<Restaurant>
    {
        public RestaurantType()
        {
            Field<NonNullGraphType<GuidGraphType>>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("line1");
            Field<StringGraphType>("line2");
            Field<StringGraphType>("suburb");
            Field<StringGraphType>("postcode");
            Field<OwnerType, Owner>("owner");
        }
    }
}
