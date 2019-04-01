using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackUs.Migrations
{
    public partial class addalotsofthing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Rating_RatingId",
                table: "Feedbacks",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Rating_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Feedbacks");
        }
    }
}
