using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anime_product_Productid",
                table: "anime");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_product_Productid",
                table: "movie");

            migrationBuilder.DropForeignKey(
                name: "FK_serie_product_Productid",
                table: "serie");

            migrationBuilder.DropForeignKey(
                name: "FK_yorum_user_Userid",
                table: "yorum");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "yorum",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_yorum_Userid",
                table: "yorum",
                newName: "IX_yorum_userId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "serie",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_serie_Productid",
                table: "serie",
                newName: "IX_serie_productId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "movie",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_Productid",
                table: "movie",
                newName: "IX_movie_productId");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "anime",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_anime_Productid",
                table: "anime",
                newName: "IX_anime_productId");

            migrationBuilder.AddColumn<int>(
                name: "producId",
                table: "yorum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fragman",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idName",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_yorum_producId",
                table: "yorum",
                column: "producId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_yorum_product_producId",
                table: "yorum",
                column: "producId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_yorum_user_userId",
                table: "yorum",
                column: "userId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropForeignKey(
                name: "FK_yorum_product_producId",
                table: "yorum");

            migrationBuilder.DropForeignKey(
                name: "FK_yorum_user_userId",
                table: "yorum");

            migrationBuilder.DropIndex(
                name: "IX_yorum_producId",
                table: "yorum");

            migrationBuilder.DropColumn(
                name: "producId",
                table: "yorum");

            migrationBuilder.DropColumn(
                name: "fragman",
                table: "product");

            migrationBuilder.DropColumn(
                name: "idName",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "yorum",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_yorum_userId",
                table: "yorum",
                newName: "IX_yorum_Userid");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "serie",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_serie_productId",
                table: "serie",
                newName: "IX_serie_Productid");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "movie",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_movie_productId",
                table: "movie",
                newName: "IX_movie_Productid");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "anime",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_anime_productId",
                table: "anime",
                newName: "IX_anime_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_anime_product_Productid",
                table: "anime",
                column: "Productid",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_product_Productid",
                table: "movie",
                column: "Productid",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serie_product_Productid",
                table: "serie",
                column: "Productid",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_yorum_user_Userid",
                table: "yorum",
                column: "Userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
