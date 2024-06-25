namespace SoldierFit.Core.Contracts
{
    using SoldierFit.Core.Models.Workout;

    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureWorkoutsAsync();

        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastWorkoutsAsync();

        Task<bool> WorkoutWithSameNameExistsAsync(string title);

        Task CreateAsync(CreateWorkoutViewModel model, int athleteId);

        bool WorkoutDateIsInRange(DateTime date);

        bool WorkoutTimeIsAtLeastThreeHoursInFuture(DateTime date, TimeSpan time);

        Task<IEnumerable<WorkoutIndexViewModel>> GetWorkoutsByUserId(int id);

        Task<WorkoutDetailsViewModel?> GetWorkoutById(int id);

        Task<bool> ExistsByIdAsync(int id);
    }
}
