namespace SoldierFit.Core.Contracts
{
    using SoldierFit.Core.Enumerations;
    using SoldierFit.Core.Models.Workout;

    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureWorkoutsAsync();

        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastWorkoutsAsync();

        Task<bool> WorkoutWithSameNameExistsAsync(string title);

        Task CreateAsync(CreateWorkoutViewModel model, int athleteId);

        bool WorkoutDateIsInRange(DateTime date);

        bool WorkoutTimeIsAtLeastThreeHoursInFuture(DateTime date, TimeSpan time);

        Task<WorkoutQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            WorkoutSorting sorting = WorkoutSorting.Newest,
            int currentPage = 1,
            int workoutsPerPage = 0);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();
    }
}
