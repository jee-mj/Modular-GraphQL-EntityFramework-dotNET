using GraphQL.Types;
using Model;

namespace API.Type
{
    public class RestaurantType : ObjectGraphType<Restaurant>
    {
        public RestaurantType()
        {
            Field(r => r.Id);
            Field(r => r.Name);
            Field(r => r.Line1);
            Field(r => r.Line2);
            Field(r => r.Suburb);
            Field(r => r.Postcode);
        }
    }
}
