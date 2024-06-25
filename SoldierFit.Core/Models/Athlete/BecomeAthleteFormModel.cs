namespace SoldierFit.Core.Models.Athlete
{
    using System.ComponentModel.DataAnnotations;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;
    using static SoldierFit.Infrastructure.Constants.DataConstraints;

    public class BecomeAthleteFormModel : AthleteIndexViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [Range(AthleteAgeMinValue,
            AthleteAgeMaxValue,
            ErrorMessage = ValueMessage)]
        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
