namespace SoldierFit.Core.Models.Workout
{
	public class FutureAndPastWorkoutsViewModel
    {
		public FutureAndPastWorkoutsViewModel()
		{
			FutureWorkouts = new List<WorkoutIndexViewModel>();
            PastWorkouts = new List<WorkoutIndexViewModel>();
        }

		public IEnumerable<WorkoutIndexViewModel> FutureWorkouts { get; set; } 
		public IEnumerable<WorkoutIndexViewModel> PastWorkouts { get; set; } 
    }
}