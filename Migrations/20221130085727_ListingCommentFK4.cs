using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class ListingCommentFK4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ListingId",
                table: "Comments");

            migrationBuilder.AddColumn<long>(
                name: "comments",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_comments",
                table: "Comments",
                column: "comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Listings_comments",
                table: "Comments",
                column: "comments",
                principalTable: "Listings",
                principalColumn: "ListingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Listings_comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "comments",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ListingId",
                table: "Comments",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Listings_ListingId",
                table: "Comments",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
