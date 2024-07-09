using SoldierFit.Core.Models.Workout;

namespace SoldierFit.Core.Contracts
{
    /// <summary>
    /// Provides methods for managing athlete data.
    /// </summary>
    public interface IAthleteService
    {
        /// <summary>
        /// Creates a new athlete.
        /// </summary>
        /// <param name="firstName">The first name of the athlete.</param>
        /// <param name="middleName">The middle name of the athlete.</param>
        /// <param name="lastName">The last name of the athlete.</param>
        /// <param name="age">The age of the athlete.</param>
        /// <param name="phoneNumber">The phone number of the athlete.</param>
        /// <param name="email">The email address of the athlete.</param>
        /// <param name="userId">The user identifier associated with the athlete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateAsync(
            string firstName,
            string middleName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string userId);

        /// <summary>
        /// Checks if an athlete exists by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier to check.</param>
        /// <returns>A <see cref="Task{Boolean}"/> indicating whether the athlete exists.</returns>
        Task<bool> ExistByIdAsync(string userId);

        /// <summary>
        /// Checks if a phone number is already associated with an athlete.
        /// </summary>
        /// <param name="phoneNumber">The phone number to check.</param>
        /// <returns>A <see cref="Task{Boolean}"/> indicating whether the phone number exists.</returns>
        Task<bool> UserWithPhoneExistsAlready(string phoneNumber);

        /// <summary>
        /// Gets the athlete identifier by user identifier.
        /// </summary>
        /// <param name="userId">The current user identifier to search for.</param>
        /// <returns>A <see cref="Task{Nullable{Int32}}"/> representing the athlete identifier, or <c>null</c> if not found.</returns>
        Task<int?> GetAthleteIdAsync(string userId);

        /// <summary>
        /// Checks if the current athlete is a participant in a specific workout.
        /// </summary>
        /// <param name="workoutId">The workout identifier to check.</param>
        /// <param name="athleteId">The athlete identifier to check.</param>
        /// <returns>A <see cref="Task{Boolean}"/> indicating whether the athlete is a participant in the specified workout.</returns>
        Task<bool> CurrentAthleteIsParticipant(int workoutId, int athleteId);
    }
}
