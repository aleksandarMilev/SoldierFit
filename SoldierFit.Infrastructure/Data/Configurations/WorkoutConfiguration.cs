namespace SoldierFit.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoldierFit.Infrastructure.Data.Models;
    using SoldierFit.Infrastructure.Data.SeedData;

    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.HasData(DataSeeder.SeedWorkouts());
        }
    }
}
