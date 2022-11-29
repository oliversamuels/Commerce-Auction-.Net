using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Migrations
{
    public partial class ActiveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveStatus",
                table: "Listings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Listings");
        }
    }
}
