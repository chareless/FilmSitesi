using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Data.Migrations
{
    public partial class proupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sliderUrl",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "yanUrl",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sliderUrl",
                table: "product");

            migrationBuilder.DropColumn(
                name: "yanUrl",
                table: "product");
        }
    }
}
