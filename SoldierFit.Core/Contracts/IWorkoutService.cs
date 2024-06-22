namespace SoldierFit.Core.Contracts
{
    using SoldierFit.Core.Models;

    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDto>> LastThreeWorkoutsAsync();

        Task<IEnumerable<WorkoutDto>> AllWorkoutsAsync();
    }
}
