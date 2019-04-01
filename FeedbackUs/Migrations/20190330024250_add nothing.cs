using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackUs.Migrations
{
    public partial class addnothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatingName",
                table: "Feedbacks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingName",
                table: "Feedbacks");
        }
    }
}
