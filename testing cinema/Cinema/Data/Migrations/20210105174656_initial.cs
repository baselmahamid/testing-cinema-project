using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDetailsViewmodel",
                table: "MovieDetailsViewmodel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MovieDetailsViewmodel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MovieDetailsViewmodel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seat",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hall",
                table: "MovieDetailsViewmodel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seat",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hall",
                table: "MovieDetails",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDetailsViewmodel",
                table: "MovieDetailsViewmodel",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDetailsViewmodel",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "hall",
                table: "MovieDetailsViewmodel");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "hall",
                table: "MovieDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MovieDetailsViewmodel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MovieDetailsViewmodel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDetailsViewmodel",
                table: "MovieDetailsViewmodel",
                column: "Id");
        }
    }
}
