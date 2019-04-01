using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackUs.Migrations
{
    public partial class addonemorething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RDURL",
                table: "Rating",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RDURL",
                table: "Rating");
        }
    }
}
