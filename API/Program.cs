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

            var applicationString = builder.Configuration.GetConnectionString("database") ?? throw new InvalidOperationException("'database' not found.");

            builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer("database"); }, ServiceLifetime.Singleton);


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



            //app.MapGet("", (HttpContext httpContext) =>
            //{
            //});

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