namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents the mapping table between Athletes and Workouts.
    /// </summary>
    [Comment("AthletesWorkouts map table")]
    public class AthleteWorkout
    {
        /// <summary>
        /// Gets or sets the identifier of the Athlete.
        /// </summary>
        [Required]
        [Comment("Athlete identifier")]
        public int AthleteId { get; set; }

        /// <summary>
        /// Gets or sets the Athlete entity associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        /// <summary>
        /// Gets or sets the identifier of the Workout.
        /// </summary>
        [Required]
        [Comment("Workout identifier")]
        public int WorkoutId { get; set; }

        /// <summary>
        /// Gets or sets the Workout entity associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; } = null!;
    }
}
