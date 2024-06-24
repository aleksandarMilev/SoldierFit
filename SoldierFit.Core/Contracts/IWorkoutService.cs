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
    }
}
