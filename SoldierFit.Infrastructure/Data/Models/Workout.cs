namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Infrastructure.Data.Enumerations;
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
        /// Gets or sets the time when the workout will be performed.
        /// </summary>
        [Required]
        [Comment("The start time of the workout")]
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Gets or sets the brief description of the workout (max 100 characters).
        /// </summary>
        [MaxLength(WorkoutBriefDescriptionMaxLength)]
        [Comment("Brief description of the workout")]
        public string BriefDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the full description of the workout (max 2000 characters).
        /// </summary>
        [MaxLength(WorkoutFullDescriptionMaxLength)]
        [Comment("Full description of the workout")]
        public string FullDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the image URL for the workout.
        /// </summary>
        [Required]
        [MaxLength(WorkoutImageUrlMaxLength)]
        [Comment("Workout image url")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the identifier of the Athlete user which added the workout.
        /// </summary>
        [Required]
        [Comment("Athlete added the workout identifier")]
        public int AthleteId { get; set; }

        /// <summary>
        /// Gets or sets the Athlete user which added the workout.
        /// </summary>
        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        /// <summary>
        /// Gets or sets the category of the workout.
        /// </summary>
        [Required]
        [Comment("Workout category")]
        public Category CategoryName { get; set; } 

        /// <summary>
        /// Gets or sets a value indicating whether the workout is for beginners.
        /// </summary>
        [Required]
        [Comment("Indicates if the workout is for beginners")]
        public bool IsForBeginners { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of participants for the workout.
        /// </summary>
        [Required]
        [Comment("Maximum number of participants for the workout")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// Gets or sets the current number of participants for the workout.
        /// </summary>
        [Required]
        [Comment("Current number of participants for the workout")]
        public int CurrentParticipants { get; set; }
    }
}
