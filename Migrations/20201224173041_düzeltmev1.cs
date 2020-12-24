using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Migrations
{
    public partial class düzeltmev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anime_product_productId",
                table: "anime");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_product_productId",
                table: "movie");

            migrationBuilder.DropForeignKey(
                name: "FK_serie_product_productId",
                table: "serie");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "serie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "anime",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_anime_product_productId",
                table: "anime",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_product_productId",
                table: "movie",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_serie_product_productId",
                table: "serie",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anime_product_productId",
                table: "anime");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_product_productId",
                table: "movie");

            migrationBuilder.DropForeignKey(
                name: "FK_serie_product_productId",
                table: "serie");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "serie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "anime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_anime_product_productId",
                table: "anime",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_product_productId",
                table: "movie",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serie_product_productId",
                table: "serie",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
