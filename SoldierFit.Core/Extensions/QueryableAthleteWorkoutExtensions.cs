namespace SoldierFit.Core.Extensions
{
    using SoldierFit.Core.Models.Workout;
    using SoldierFit.Infrastructure.Data.Models;

    /// <summary>
    /// Extension methods for querying and projecting AthleteWorkout entities to WorkoutIndexViewModels.
    /// </summary>
    public static class QueryableAthleteWorkoutExtensions
    {
        /// <summary>
        /// Projects IQueryable of AthleteWorkout entities to IQueryable of WorkoutIndexViewModels.
        /// </summary>
        /// <param name="athleteWorkout">Queryable of AthleteWorkout entities.</param>
        /// <returns>IQueryable of WorkoutIndexViewModel representing the projected workouts.</returns>
        public static IQueryable<WorkoutIndexViewModel> MakeProjectionToIndexViewModel(this IQueryable<AthleteWorkout> athleteWorkout)
            => athleteWorkout
                 .Select(w => new WorkoutIndexViewModel()
                 {
                     Id = w.WorkoutId,
                     Title = w.Workout.Title,
                     Date = w.Workout.Date,
                     Time = w.Workout.Time,
                     ImageUrl = w.Workout.ImageUrl,
                     BriefDescription = w.Workout.BriefDescription,
                     CategoryName = w.Workout.CategoryName,
                     MaxParticipants = w.Workout.MaxParticipants,
                     IsForBeginners = w.Workout.IsForBeginners,
                     AthleteId = w.AthleteId
                 });
    }
}
