namespace SoldierFit.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Infrastructure.Data.Configurations;
    using SoldierFit.Infrastructure.Data.Models;

    /// <summary>
    /// Represents the application's database context, extending IdentityDbContext for ASP.NET Identity.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContextOptions to be used for configuring the context.</param>
        /// <exception cref="InvalidOperationException">Thrown when the 'DefaultConnection' connection string is not found in the configuration.</exception>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet representing the Athletes table.
        /// </summary>
        public DbSet<Athlete> Athletes { get; set; } = null!;

        /// <summary>
        /// Gets or sets the DbSet representing the Workouts table.
        /// </summary>
        public DbSet<Workout> Workouts { get; set; } = null!;

        /// <summary>
        /// Gets or sets the DbSet representing the many-to-many relationship between athletes and workouts.
        /// </summary>
        public DbSet<AthleteWorkout> AthletesWorkouts { get; set; } = null!;

        /// <summary>
        /// Configures the model by applying entity configurations.
        /// </summary>
        /// <param name="builder">The model builder used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AthleteWorkoutConfiguration());
            builder.ApplyConfiguration(new AthleteConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
        }
    }
}
