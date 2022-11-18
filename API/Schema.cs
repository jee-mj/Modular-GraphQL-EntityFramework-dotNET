using API.Type;
using GraphQL;
using GraphQL.Types;

namespace API
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<Query.Query>();

        }
    }
}
