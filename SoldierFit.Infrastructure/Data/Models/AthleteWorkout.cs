namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents the many-to-many relationship between athletes and workouts.
    /// </summary>
    [Comment("AthletesWorkouts table")]
    public class AthleteWorkout
    {
        /// <summary>
        /// Gets or sets the athlete identifier.
        /// </summary>
        [Required]
        [Comment("Athlete identifier")]
        public int AthleteId { get; set; }

        /// <summary>
        /// Navigation property for the athlete.
        /// </summary>
        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        /// <summary>
        /// Gets or sets the workout identifier.
        /// </summary>]
        [Required]
        [Comment("Workout identifier")]
        public int WorkoutId { get; set; }

        /// <summary>
        /// Navigation property for the workout.
        /// </summary>
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; } = null!;
    }
}
