using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Data.Migrations
{
    public partial class fotoekleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "detailUrl",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detailUrl",
                table: "product");
        }
    }
}
