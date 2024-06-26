﻿namespace SoldierFit.Core.Models.Workout
{
    using System.ComponentModel.DataAnnotations;
    using SoldierFit.Core.Models.Athlete;
    using SoldierFit.Infrastructure.Data.Models;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class WorkoutDetailsViewModel : WorkoutIndexViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            WorkoutFullDescriptionMaxLength,
            MinimumLength = WorkoutFullDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Full Description")]
        public string FullDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(
            WorkoutCurrentParticipantsMinValue,
            WorkoutParticipantsMaxValue,
            ErrorMessage = MaxParticipantsErrorMessage)]
        [Display(Name = "Current Athletes count")]
        public int CurrentParticipants { get; set; }

        public AthleteIndexViewModel Athlete { get; set; } = null!;

        public ICollection<AthleteWorkout> AthletesWorkouts { get; set; } = new List<AthleteWorkout>();
    }
}
