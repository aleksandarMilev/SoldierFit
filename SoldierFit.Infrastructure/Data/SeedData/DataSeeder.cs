namespace SoldierFit.Infrastructure.Data.SeedData
{
    using SoldierFit.Infrastructure.Data.Models;

    public class DataSeeder
    {
        public static IEnumerable<Athlete> SeedAthletes()
        {
            return new Athlete[]
            {
                new()
                {
                    Id = 1,
                    FirstName = "John",
                    MiddleName = "A.",
                    LastName = "Doe",
                    Age = 30,
                    PhoneNumber = "111111111",
                    Email = "test1@abv.bg",
                    UserId = "8c2ec506-706c-4cb2-81eb-0bfcf47e7965"
                },

                new()
                {
                    Id = 2,
                    FirstName = "Jane",
                    MiddleName = "B.",
                    LastName = "Smith",
                    Age = 25,
                    PhoneNumber = "222222222",
                    Email = "test2@abv.bg",
                    UserId = "a117846b-9438-445c-b8f5-376366419a71"
                },

                new()
                {
                    Id = 3,
                    FirstName = "Michael",
                    MiddleName = "C.",
                    LastName = "Johnson",
                    Age = 35,
                    PhoneNumber = "333333333",
                    Email = "test3@abv.bg",
                    UserId = "8e19ada9-b7ed-4f16-82b3-7f4f1924ff64"
                },

                new()
                {
                    Id = 4,
                    FirstName = "Emily",
                    MiddleName = "D.",
                    LastName = "Brown",
                    Age = 28,
                    PhoneNumber = "444444444",
                    Email = "test4@abv.bg",
                    UserId = "0c12411c-88c2-4853-9fd5-7f6a9630e41e"
                }
            };
        }

        public static IEnumerable<Workout> SeedWorkouts()
        {
            return new Workout[]
            {
                new()
                {
                    Id = 1,
                    Title = "Murph",
                    Date = DateTime.Parse("2024-06-25 08:00:00"),
                    Description = "Murph is a CrossFit Hero workout that stands as a testament to the enduring legacy of U.S. Navy SEAL Lt. Michael Murphy, who died heroically in the line of duty in Afghanistan on June 28, 2005.",
                    ImageUrl = "https://i.shgcdn.com/8193030c-15da-486d-8fe0-1318413edd40/-/format/auto/-/preview/3000x3000/-/quality/lighter/"
                },

                new()
                {
                    Id = 2,
                    Title = "Fran",
                    Date = DateTime.Parse("2024-06-25 15:00:00"),
                    Description = "The Fran Workout is a series of 45 total thrusters and 45 total pull-ups performed in the following combination within a 10-minute time cap.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWPoJhv5EnRXYvQmgLFnL4HGVVvu0-49ngRA&usqp=CAU"
                },

                new()
                {
                    Id = 3,
                    Title = "Cindy",
                    Date = DateTime.Parse("2024-06-25 18:00:00"),
                    Description = "Cindy is 5 pullups, 10 pushups and 15 squats for 20 minutes. A great, simple yet challenging workout. I would recommend most Athletes do Cindy with a goal of hitting 20 rounds. 20 is a great score.",
                    ImageUrl = "https://i.pinimg.com/736x/c2/70/30/c27030bf53de1bad2388a6e35eb6789a.jpg"
                },

                new()
                {
                    Id = 4,
                    Title = "Weekend Hike",
                    Date = DateTime.Parse("2024-06-25 20:00:00"),
                    Description = "The CrossFit workout Grace consists of 30 reps of one exercise — the clean & jerk — performed as quickly as possible.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVO4ZFlVqlkA0sX7WlOaJZXuKjPucVVOhfKA&usqp=CAU"
                }
            };
        }
    }
}
