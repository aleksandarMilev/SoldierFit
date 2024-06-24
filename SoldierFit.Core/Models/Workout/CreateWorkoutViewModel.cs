namespace SoldierFit.Core.Models.Workout
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class CreateWorkoutViewModel
    {
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
            WorkoutDescriptionMaxLength,
            MinimumLength = WorkoutDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            WorkoutImageUrlMaxLength,
            MinimumLength = WorkoutImageUrlMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
