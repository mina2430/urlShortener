using Microsoft.EntityFrameworkCore.Migrations;

namespace bitly.Migrations
{
    public partial class UrlShortenerAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shortUrl",
                table: "url",
                newName: "ShortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "url",
                newName: "shortUrl");
        }
    }
}
