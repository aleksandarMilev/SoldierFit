namespace SoldierFit.Core.Models.Workout
{
	public class FutureAndPastWorkoutsViewModel
    {
		public IEnumerable<WorkoutIndexViewModel> FutureWorkouts { get; set; } = new List<WorkoutIndexViewModel>();
		public IEnumerable<WorkoutIndexViewModel> PastWorkouts { get; set; } = new List<WorkoutIndexViewModel>();
    }
}