using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Seed(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        private void Seed(MigrationBuilder migrationBuilder)
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();

            migrationBuilder.Sql($@"INSERT INTO [dbo].[Owners] ([Id],[Name])
            VALUES ('{guid1}','Thomas')");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[Owners] ([Id],[Name])
            VALUES ('{guid2}','David')");

            migrationBuilder.Sql($@"INSERT INTO [dbo].[Restaurants] ([Id],[Name],[Line1],[Suburb],[Postcode],[OwnerId])
            VALUES ('{Guid.NewGuid()}','Ts Lassi','George Street','ThomasTown','4c61737369','{guid1}')");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[Restaurants] ([Id],[Name],[Line1],[Suburb],[Postcode],[OwnerId])
            VALUES ('{Guid.NewGuid()}','The Kheer House','James Street','DavidTown','4b68656572','{guid2}')");

        }
    }
}
