using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Data.Migrations
{
    public partial class ShowTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofMovie",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "DateAndTime",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MovieDetails");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTimeE",
                table: "MovieDetailsViewmodel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTimeS",
                table: "MovieDetailsViewmodel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hall",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie_Details",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie_Name",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Prices",
                table: "MovieDetailsViewmodel",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "MovieDetailsViewmodel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_Name = table.Column<string>(nullable: true),
                    Movie_Details = table.Column<string>(nullable: true),
                    MoivePicture = table.Column<string>(nullable: true),
                    Hall = table.Column<string>(nullable: true),
                    Seat = table.Column<int>(nullable: false),
                    DateAndTimeS = table.Column<DateTime>(nullable: false),
                    DateAndTimeE = table.Column<DateTime>(nullable: false),
                    Prices = table.Column<float>(nullable: false),
                    category = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTime", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "DateAndTimeE",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "DateAndTimeS",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Hall",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Movie_Details",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Movie_Name",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Prices",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MovieDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofMovie",
                table: "MovieDetailsViewmodel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MovieDetailsViewmodel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MovieDetailsViewmodel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "MovieDetailsViewmodel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAndTime",
                table: "MovieDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "MovieDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
