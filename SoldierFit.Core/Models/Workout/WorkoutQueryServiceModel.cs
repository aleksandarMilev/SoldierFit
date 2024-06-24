namespace SoldierFit.Core.Models.Workout
{
    public class WorkoutQueryServiceModel
    {
        public int TotalWorkouts { get; set; }
        public ICollection<WorkoutIndexViewModel> Workouts { get; set; } = new List<WorkoutIndexViewModel>();
    }
}
