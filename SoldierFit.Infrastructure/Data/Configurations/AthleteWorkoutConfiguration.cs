namespace SoldierFit.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoldierFit.Infrastructure.Data.Models;

    /// <summary>
    /// Configuration class for the <see cref="AthleteWorkout"/> entity.
    /// </summary>
    public class AthleteWorkoutConfiguration : IEntityTypeConfiguration<AthleteWorkout>
    {
        /// <summary>
        /// Configures the entity of type <see cref="AthleteWorkout"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<AthleteWorkout> builder)
        {
            /// <summary>
            /// Sets the composite key for the <see cref="AthleteWorkout"/> entity.
            /// </summary>
            builder.HasKey(aw => new { aw.WorkoutId, aw.AthleteId });
        }
    }
}
