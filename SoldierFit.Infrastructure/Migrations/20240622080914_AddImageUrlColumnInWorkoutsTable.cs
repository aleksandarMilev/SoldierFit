using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class AddImageUrlColumnInWorkoutsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workouts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "Workout image url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workouts");

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, 30, "test1@abv.bg", "John", "Doe", "A.", "123456789", "8c2ec506-706c-4cb2-81eb-0bfcf47e7965" },
                    { 2, 25, "test2@abv.bg", "Jane", "Smith", "B.", "987654321", "a117846b-9438-445c-b8f5-376366419a71" },
                    { 3, 35, "test3@abv.bg", "Michael", "Johnson", "C.", "555555555", "8e19ada9-b7ed-4f16-82b3-7f4f1924ff64" },
                    { 4, 28, "test4@abv.bg", "Emily", "Brown", "D.", "111111111", "0c12411c-88c2-4853-9fd5-7f6a9630e41e" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "A brisk morning run to start the day.", "Morning Run" },
                    { 2, new DateTime(2024, 6, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), "Circuit training session focusing on strength and endurance.", "Afternoon Circuit Training" },
                    { 3, new DateTime(2024, 6, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), "Relaxing yoga session to unwind after a busy day.", "Evening Yoga" },
                    { 4, new DateTime(2024, 6, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "Scenic hike through local trails with breathtaking views.", "Weekend Hike" }
                });
        }
    }
}
