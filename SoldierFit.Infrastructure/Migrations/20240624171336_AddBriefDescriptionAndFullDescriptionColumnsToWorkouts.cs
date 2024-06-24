using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class AddBriefDescriptionAndFullDescriptionColumnsToWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "BriefDescription",
                table: "Workouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Brief description of the workout");

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Workouts",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                comment: "Full description of the workout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BriefDescription",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Workouts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "",
                comment: "Workout description");
        }
    }
}
