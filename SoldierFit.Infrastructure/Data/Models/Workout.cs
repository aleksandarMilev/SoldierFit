namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;

    /// <summary>
    /// Represents a workout performed by an athlete.
    /// </summary>
    [Comment("Workouts table")]
    public class Workout
    {
        /// <summary>
        /// Gets or sets the unique identifier for the workout.
        /// </summary>
        [Key]
        [Comment("Workout identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the workout.
        /// </summary>
        [Required]
        [MaxLength(WorkoutTitleMaxLength)]
        [Comment("Workout title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date when the workout will be performed.
        /// </summary>
        [Required]
        [Comment("Workout date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the workout.
        /// </summary>
        [Required]
        [MaxLength(WorkoutDescriptionMaxLength)]
        [Comment("Workout description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the image URL for the workout
        /// </summary>
        [Required]
        [MaxLength(WorkoutImageUrlMaxLength)]
        [Comment("Workout image url")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the indentifier of the Athlete user which added the workout
        /// </summary>
        [Required]
        [Comment("Athelte added the workout identifier")]
        public int AthleteId { get; set; }

        /// <summary>
        /// Gets or sets the Athlete user which added the workout
        /// </summary>
        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;
    }
}
