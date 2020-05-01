using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiExercise.Migrations
{
    public partial class typoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barand",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Barand",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
