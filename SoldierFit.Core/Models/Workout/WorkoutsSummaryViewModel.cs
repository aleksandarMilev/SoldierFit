namespace SoldierFit.Core.Models.Workout
{
	public class WorkoutsSummaryViewModel
	{
		public IEnumerable<WorkoutIndexViewModel> FutureWorkouts { get; set; } = new List<WorkoutIndexViewModel>();
		public IEnumerable<WorkoutIndexViewModel> PastWorkouts { get; set; } = new List<WorkoutIndexViewModel>();
	}
}