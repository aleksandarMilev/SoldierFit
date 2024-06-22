namespace SoldierFit.Infrastructure.Constants
{
    /// <summary>
    /// Hold data constraints for models properties.
    /// </summary>
    public static class DataConstraints
    {
        /// <summary>
        /// Minimum length for athlete names.
        /// </summary>
        public const int AthleteNamesMinLength = 2;

        /// <summary>
        /// Maximum length for athlete names.
        /// </summary>
        public const int AthleteNamesMaxLength = 50;

        /// <summary>
        /// Minimum length for athlete email addresses.
        /// </summary>
        public const int AthleteEmailMinLength = 7;

        /// <summary>
        /// Maximum length for athlete email addresses.
        /// </summary>
        public const int AthleteEmailMaxLength = 320;

        /// <summary>
        /// Minimum length for athlete phone numbers.
        /// </summary>
        public const int AthletePhoneMinLength = 5;

        /// <summary>
        /// Maximum length for athlete phone numbers.
        /// </summary>
        public const int AthletePhoneMaxLength = 15;

        /// <summary>
        /// Minimum length for workout titles.
        /// </summary>
        public const int WorkoutTitleMinLength = 2;

        /// <summary>
        /// Maximum length for workout titles.
        /// </summary>
        public const int WorkoutTitleMaxLength = 50;

        /// <summary>
        /// Minimum length for workout descriptions.
        /// </summary>
        public const int WorkoutDescriptionMinLength = 10;

        /// <summary>
        /// Maximum length for workout descriptions.
        /// </summary>
        public const int WorkoutDescriptionMaxLength = 600;

        /// <summary>
        /// Minimum length for workout image url.
        /// </summary>
        public const int WorkoutImageUrlMinLength = 10;

        /// <summary>
        /// Maximum length for workout image url.
        /// </summary>
        public const int WorkoutImageUrlMaxLength = 255;
    }
}