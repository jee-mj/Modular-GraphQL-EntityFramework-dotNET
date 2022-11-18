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

            var applicationString = builder.Configuration.GetConnectionString("database") ?? throw new InvalidOperationException("Connection string 'database' not found.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(applicationString));
            builder.Services.AddScoped<ISchema, Schema.Schema>();
            builder.Services.AddScoped<IRepository, Repository>();

            builder.Services.AddGraphQL(builder => builder
            .AddErrorInfoProvider(options => options.ExposeExceptionDetails = true)
            .AddSystemTextJson()
            .AddGraphTypes()
            .AddDataLoader()
            .AddExecutionStrategy<ParallelExecutionStrategy>(OperationType.Query));

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
