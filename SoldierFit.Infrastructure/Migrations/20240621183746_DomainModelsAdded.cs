using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class DomainModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Athlete identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Athlete first name"),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Athlete middle name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Athlete last name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Athlete age"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Athlete phone number"),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false, comment: "Athlete email address"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Athletes table");

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Workout identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Workout title"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Workout date"),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false, comment: "Workout description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                },
                comment: "Workouts table");

            migrationBuilder.CreateTable(
                name: "AthletesWorkouts",
                columns: table => new
                {
                    AthleteId = table.Column<int>(type: "int", nullable: false, comment: "Athlete identifier"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false, comment: "Workout identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletesWorkouts", x => new { x.WorkoutId, x.AthleteId });
                    table.ForeignKey(
                        name: "FK_AthletesWorkouts_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthletesWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "AthletesWorkouts table");

            migrationBuilder.CreateTable(
                name: "AthleteWorkout",
                columns: table => new
                {
                    AthletesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteWorkout", x => new { x.AthletesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_AthleteWorkout_Athletes_AthletesId",
                        column: x => x.AthletesId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteWorkout_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_UserId",
                table: "Athletes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesWorkouts_AthleteId",
                table: "AthletesWorkouts",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteWorkout_WorkoutsId",
                table: "AthleteWorkout",
                column: "WorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletesWorkouts");

            migrationBuilder.DropTable(
                name: "AthleteWorkout");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
