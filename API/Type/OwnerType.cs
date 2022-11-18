using API.Data;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Model;

namespace API.Type
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType()
        {
            Field<NonNullGraphType<GuidGraphType>>("id");
            Field<StringGraphType>("name");
            Field<ListGraphType<RestaurantType>>("restaurants");
            //    .Description("Restaurants owned.");
        }
    }
}
