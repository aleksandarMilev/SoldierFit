namespace SoldierFit.Core.Models.Athlete
{
    using System.ComponentModel.DataAnnotations;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;

    public class BecomeAthleteFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            AthleteNamesMaxLength,
            MinimumLength = AthleteNamesMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            AthleteNamesMaxLength,
            MinimumLength = AthleteNamesMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            AthleteNamesMaxLength,
            MinimumLength = AthleteNamesMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(AthleteAgeMinValue,
            AthleteAgeMaxValue,
            ErrorMessage = ValueMessage)]
        public int Age { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            AthletePhoneMaxLength,
            MinimumLength = AthletePhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
