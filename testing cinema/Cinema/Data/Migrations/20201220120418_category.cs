using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Data.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "MovieDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "category",
                table: "MovieDetails");
        }
    }
}
