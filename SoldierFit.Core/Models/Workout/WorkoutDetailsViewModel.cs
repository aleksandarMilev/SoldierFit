﻿namespace SoldierFit.Core.Models.Workout
{
    using System.ComponentModel.DataAnnotations;
    using SoldierFit.Core.Models.Athlete;
    using SoldierFit.Infrastructure.Data.Enumerations;
    using SoldierFit.Infrastructure.Data.Models;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class WorkoutDetailsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            WorkoutTitleMaxLength,
            MinimumLength = WorkoutTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [DataType(DataType.Date)]
        [Display(Name = "Workout Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = RequiredMessage)]
        [DataType(DataType.Time)]
        [Display(Name = "Workout Time")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            WorkoutBriefDescriptionMaxLength,
            MinimumLength = WorkoutBriefDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Brief Description")]
        public string BriefDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            WorkoutImageUrlMaxLength,
            MinimumLength = WorkoutImageUrlMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Category")]
        public Category CategoryName { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Is For Beginners")]
        public bool IsForBeginners { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(
            WorkoutParticipantsMinValue,
            WorkoutParticipantsMaxValue,
            ErrorMessage = MaxParticipantsErrorMessage)]
        [Display(Name = "Max Participants")]
        public int MaxParticipants { get; set; }

        public int AthleteId { get; set; }

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
