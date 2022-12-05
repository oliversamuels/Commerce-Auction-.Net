using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class WatchlistII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_WatchLists_WatchListId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_WatchListId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "Listings");

            migrationBuilder.CreateTable(
                name: "ListingWatchList",
                columns: table => new
                {
                    WatchListsWatchListId = table.Column<long>(type: "bigint", nullable: false),
                    watchlist = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingWatchList", x => new { x.WatchListsWatchListId, x.watchlist });
                    table.ForeignKey(
                        name: "FK_ListingWatchList_Listings_watchlist",
                        column: x => x.watchlist,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingWatchList_WatchLists_WatchListsWatchListId",
                        column: x => x.WatchListsWatchListId,
                        principalTable: "WatchLists",
                        principalColumn: "WatchListId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListingWatchList_watchlist",
                table: "ListingWatchList",
                column: "watchlist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingWatchList");

            migrationBuilder.AddColumn<long>(
                name: "WatchListId",
                table: "Listings",
                type: "bigint",
                nullable: true);

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
    }
}
