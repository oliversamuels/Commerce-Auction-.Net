using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Comments_CommentId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CommentId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Listings");

            migrationBuilder.AddColumn<long>(
                name: "ListingId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "ListingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "comments",
                table: "Comments");

            migrationBuilder.AddColumn<long>(
                name: "CommentId",
                table: "Listings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CommentId",
                table: "Listings",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Comments_CommentId",
                table: "Listings",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");
        }
    }
}
