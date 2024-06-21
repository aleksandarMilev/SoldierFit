﻿namespace SoldierFit.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
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
        /// Gets or sets the date when the workout was performed.
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
        /// Navigation property for the athletes who performed the workout.
        /// </summary>
        public ICollection<Athlete> Athletes { get; set; } = new List<Athlete>();
    }
}
