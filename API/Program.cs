using API.Repositories;
using API.Type;
using API.Data;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using GraphQLParser.AST;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var applicationString = builder.Configuration.GetConnectionString("database") ?? throw new InvalidOperationException("Connection string 'database' not found.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(applicationString));
            builder.Services.AddScoped<ISchema, Schema>();
            builder.Services.AddScoped<IRepository, Repository>();

            builder.Services.AddGraphQL(builder => builder
            .AddErrorInfoProvider(options => options.ExposeExceptionDetails = true)
            .AddSystemTextJson()
            .AddGraphTypes()
            .AddDataLoader()
            .AddExecutionStrategy<SerialExecutionStrategy>(OperationType.Query));

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();
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