using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSitesi.Migrations
{
    public partial class sitebaslangic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<int>(type: "int", nullable: false),
                    hakkında = table.Column<int>(type: "int", nullable: false),
                    kategori = table.Column<int>(type: "int", nullable: false),
                    yapımcı = table.Column<int>(type: "int", nullable: false),
                    tarihi = table.Column<int>(type: "int", nullable: false),
                    tur = table.Column<int>(type: "int", nullable: false),
                    skor = table.Column<int>(type: "int", nullable: false),
                    süre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "anime",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime", x => x.id);
                    table.ForeignKey(
                        name: "FK_anime_product_Productid",
                        column: x => x.Productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_movie_product_Productid",
                        column: x => x.Productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "serie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serie", x => x.id);
                    table.ForeignKey(
                        name: "FK_serie_product_Productid",
                        column: x => x.Productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "yorum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yorum", x => x.id);
                    table.ForeignKey(
                        name: "FK_yorum_user_Userid",
                        column: x => x.Userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anime_Productid",
                table: "anime",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_movie_Productid",
                table: "movie",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_serie_Productid",
                table: "serie",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_yorum_Userid",
                table: "yorum",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anime");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "serie");

            migrationBuilder.DropTable(
                name: "yorum");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
