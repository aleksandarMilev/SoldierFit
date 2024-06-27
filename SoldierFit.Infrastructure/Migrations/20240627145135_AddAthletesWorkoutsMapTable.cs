using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class AddAthletesWorkoutsMapTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id");
                },
                comment: "AthletesWorkouts map table");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesWorkouts_AthleteId",
                table: "AthletesWorkouts",
                column: "AthleteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletesWorkouts");
        }
    }
}
