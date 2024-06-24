namespace SoldierFit.Infrastructure.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The field {0} is required";

        public const string LengthMessage = "The field {0} should be between {2} and {1} characters long";

        public const string ValueMessage = "The field {0} should be in the range {1} - {2}";

        public const string PhoneExistsMessage = "Athlete with phone - {0} already exists";

        public const string WorkoutWithSameNameExists = "Workout '{0}' already exists";

        public const string InvalidDate = "The workout date must be between {0} and {1}. Please select a date within this range.";

        public const string InvalidTime = "The workout time must be at least 3 hours in the future from the current time.";
    }
}
