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
                    PhoneNumber = "123456789",
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
                    PhoneNumber = "987654321",
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
                    PhoneNumber = "555555555",
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
                    PhoneNumber = "111111111",
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
                    Title = "Morning Run",
                    Date = DateTime.Parse("2024-06-22 08:00:00"),
                    Description = "A brisk morning run to start the day.",
                },

                new()
                {
                    Id = 2,
                    Title = "Afternoon Circuit Training",
                    Date = DateTime.Parse("2024-06-22 15:00:00"),
                    Description = "Circuit training session focusing on strength and endurance.",
                },

                new()
                {
                    Id = 3,
                    Title = "Evening Yoga",
                    Date = DateTime.Parse("2024-06-23 18:30:00"),
                    Description = "Relaxing yoga session to unwind after a busy day.",
                },

                new()
                {
                    Id = 4,
                    Title = "Weekend Hike",
                    Date = DateTime.Parse("2024-06-25 10:00:00"),
                    Description = "Scenic hike through local trails with breathtaking views.",
                }
            };
        }
    }
}
