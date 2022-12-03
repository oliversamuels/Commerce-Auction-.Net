using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class BidsandListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Bids_BidId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_BidId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "BidId",
                table: "Listings",
                newName: "bids");

            migrationBuilder.AddColumn<long>(
                name: "ListingId",
                table: "Bids",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Bids",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Bids",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_bids",
                table: "Listings",
                column: "bids",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId1",
                table: "Bids",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_IdentityUser_UserId1",
                table: "Bids",
                column: "UserId1",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Bids_bids",
                table: "Listings",
                column: "bids",
                principalTable: "Bids",
                principalColumn: "BidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_IdentityUser_UserId1",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Bids_bids",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Listings_bids",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Bids_UserId1",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "bids",
                table: "Listings",
                newName: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_BidId",
                table: "Listings",
                column: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Bids_BidId",
                table: "Listings",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "BidId");
        }
    }
}
