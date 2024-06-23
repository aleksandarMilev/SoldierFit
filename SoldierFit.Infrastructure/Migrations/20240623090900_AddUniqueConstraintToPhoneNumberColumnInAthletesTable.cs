using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoldierFit.Infrastructure.Migrations
{
    public partial class AddUniqueConstraintToPhoneNumberColumnInAthletesTable : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_PhoneNumber",
                table: "Athletes",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Athletes_PhoneNumber",
                table: "Athletes");

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, 30, "test1@abv.bg", "John", "Doe", "A.", "111111111", "8c2ec506-706c-4cb2-81eb-0bfcf47e7965" },
                    { 2, 25, "test2@abv.bg", "Jane", "Smith", "B.", "222222222", "a117846b-9438-445c-b8f5-376366419a71" },
                    { 3, 35, "test3@abv.bg", "Michael", "Johnson", "C.", "333333333", "8e19ada9-b7ed-4f16-82b3-7f4f1924ff64" },
                    { 4, 28, "test4@abv.bg", "Emily", "Brown", "D.", "444444444", "0c12411c-88c2-4853-9fd5-7f6a9630e41e" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Murph is a CrossFit Hero workout that stands as a testament to the enduring legacy of U.S. Navy SEAL Lt. Michael Murphy, who died heroically in the line of duty in Afghanistan on June 28, 2005.", "https://i.shgcdn.com/8193030c-15da-486d-8fe0-1318413edd40/-/format/auto/-/preview/3000x3000/-/quality/lighter/", "Murph" },
                    { 2, new DateTime(2024, 6, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), "The Fran Workout is a series of 45 total thrusters and 45 total pull-ups performed in the following combination within a 10-minute time cap.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWPoJhv5EnRXYvQmgLFnL4HGVVvu0-49ngRA&usqp=CAU", "Fran" },
                    { 3, new DateTime(2024, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "Cindy is 5 pullups, 10 pushups and 15 squats for 20 minutes. A great, simple yet challenging workout. I would recommend most Athletes do Cindy with a goal of hitting 20 rounds. 20 is a great score.", "https://i.pinimg.com/736x/c2/70/30/c27030bf53de1bad2388a6e35eb6789a.jpg", "Cindy" },
                    { 4, new DateTime(2024, 6, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "The CrossFit workout Grace consists of 30 reps of one exercise — the clean & jerk — performed as quickly as possible.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVO4ZFlVqlkA0sX7WlOaJZXuKjPucVVOhfKA&usqp=CAU", "Weekend Hike" }
                });
        }
    }
}
