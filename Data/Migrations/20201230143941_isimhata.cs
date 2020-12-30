using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Data.Migrations
{
    public partial class isimhata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "yapımcı",
                table: "product",
                newName: "yapimci");

            migrationBuilder.RenameColumn(
                name: "süre",
                table: "product",
                newName: "sure");

            migrationBuilder.RenameColumn(
                name: "hakkında",
                table: "product",
                newName: "hakkinda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "yapimci",
                table: "product",
                newName: "yapımcı");

            migrationBuilder.RenameColumn(
                name: "sure",
                table: "product",
                newName: "süre");

            migrationBuilder.RenameColumn(
                name: "hakkinda",
                table: "product",
                newName: "hakkında");
        }
    }
}
