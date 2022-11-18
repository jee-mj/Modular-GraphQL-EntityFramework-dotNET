using API.Repositories;
using API.Schema;
using API.Type;
using Database.Data;
using GraphQL;
using GraphQL.Execution;
using GraphQLParser.AST;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // You just gotta pass it in like this otherwise GraphQL freaks out </3
            builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MGEFNET;Trusted_Connection=True;MultipleActiveResultSets=true"); }, ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddSingleton<RestaurantType>();

            builder.Services.AddGraphQL(builder => builder
            .AddErrorInfoProvider(options => options.ExposeExceptionDetails = true)
            .AddSystemTextJson()
            .AddSchema<Schema.Schema>()
            .AddGraphTypes()
            .AddDataLoader()
            .AddExecutionStrategy<SerialExecutionStrategy>(OperationType.Query));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("graphql");
                endpoints.MapGraphQLGraphiQL("graphiql");
            });

            app.UseGraphQL();
            app.UseGraphQLGraphiQL();

            app.Run();
        }
    }
}
