namespace SoldierFit.Core.Models.Workout
{
    public class WorkoutIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string BriefDescription { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
