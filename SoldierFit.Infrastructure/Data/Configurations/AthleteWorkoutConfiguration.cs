namespace SoldierFit.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoldierFit.Infrastructure.Data.Models;
    using System.Reflection.Emit;

    public class AthleteWorkoutConfiguration : IEntityTypeConfiguration<AthleteWorkout>
    {
        public void Configure(EntityTypeBuilder<AthleteWorkout> builder)
        {
            builder
               .HasKey(aw => new { aw.WorkoutId, aw.AthleteId });

            builder
               .HasOne(aw => aw.Workout)
               .WithMany(a => a.AthletesWorkouts)
               .HasForeignKey(aw => aw.WorkoutId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
