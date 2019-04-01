using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackUs.Migrations
{
    public partial class addsomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Content");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Rating",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rating",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Rating",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Rating",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Rating",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Content",
                nullable: true);
        }
    }
}
