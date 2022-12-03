using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class Watchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WatchListId",
                table: "Listings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WatchLists",
                columns: table => new
                {
                    WatchListId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLists", x => x.WatchListId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_WatchListId",
                table: "Listings",
                column: "WatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_WatchLists_WatchListId",
                table: "Listings",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "WatchListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_WatchLists_WatchListId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_Listings_WatchListId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "Listings");
        }
    }
}
