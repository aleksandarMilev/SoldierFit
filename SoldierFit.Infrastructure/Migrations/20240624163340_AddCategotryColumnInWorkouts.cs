using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class AddCategotryColumnInWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AthleteId",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Athlete added the workout identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Athelte added the workout identifier");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Workout category");

            migrationBuilder.AddColumn<int>(
                name: "CurrentParticipants",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Current number of participants for the workout");

            migrationBuilder.AddColumn<bool>(
                name: "IsForBeginners",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicates if the workout is for beginners");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Maximum number of participants for the workout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CurrentParticipants",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "IsForBeginners",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "AthleteId",
                table: "Workouts",
                type: "int",
                nullable: false,
                comment: "Athelte added the workout identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Athlete added the workout identifier");
        }
    }
}
