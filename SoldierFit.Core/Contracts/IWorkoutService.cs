namespace SoldierFit.Core.Contracts
{
    using SoldierFit.Core.Models.Workout;

    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutIndexViewModel>> LastThreeWorkoutsAsync();

        Task<IEnumerable<WorkoutIndexViewModel>> AllWorkoutsAsync();
    }
}
