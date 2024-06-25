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
        /// Minimum value for athlete age.
        /// </summary>
        public const int AthleteAgeMinValue = 5;

        /// <summary>
        /// Maximum value for athlete age.
        /// </summary>
        public const int AthleteAgeMaxValue = 100;

        /// <summary>
        /// Minimum length for workout titles.
        /// </summary>
        public const int WorkoutTitleMinLength = 2;

        /// <summary>
        /// Maximum length for workout titles.
        /// </summary>
        public const int WorkoutTitleMaxLength = 50;

        /// <summary>
        /// Minimum length for the workout brief description.
        /// </summary>
        public const int WorkoutBriefDescriptionMinLength = 10;

        /// <summary>
        /// Maximum length for the workout brief description.
        /// </summary>
        public const int WorkoutBriefDescriptionMaxLength = 100;

        /// <summary>
        /// Minimum length for the workout full description.
        /// </summary>
        public const int WorkoutFullDescriptionMinLength = 50;

        /// <summary>
        /// Maximum length for the workout full description.
        /// </summary>
        public const int WorkoutFullDescriptionMaxLength = 2_000;

        /// <summary>
        /// Minimum length for workout image url.
        /// </summary>
        public const int WorkoutImageUrlMinLength = 10;

        /// <summary>
        /// Maximum length for workout image url.
        /// </summary>
        public const int WorkoutImageUrlMaxLength = 255;

        /// <summary>
        /// Minimum value for workout participants count.
        /// </summary>
        public const int WorkoutParticipantsMinValue = 1;

        /// <summary>
        /// Maximum value for workout participants count.
        /// </summary>
        public const int WorkoutParticipantsMaxValue = 15;

        /// <summary>
        /// Minimum value for current participants count.
        /// </summary>
        public const int WorkoutCurrentParticipantsMinValue = 0;
    }
}