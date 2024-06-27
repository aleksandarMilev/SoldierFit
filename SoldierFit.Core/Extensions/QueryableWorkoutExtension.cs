namespace SoldierFit.Core.Extensions
{
    using SoldierFit.Core.Models.Workout;
    using SoldierFit.Infrastructure.Data.Models;

    /// <summary>
    /// Extension methods for IQueryable&lt;Workout&gt; to perform projections to ViewModel types.
    /// </summary>
    public static class QueryableWorkoutExtension
    {
        /// <summary>
        /// Projects an IQueryable&lt;Workout&gt; to an IQueryable&lt;WorkoutIndexViewModel&gt;,
        /// selecting specific properties.
        /// </summary>
        /// <param name="workouts">The source IQueryable&lt;Workout&gt; to project from.</param>
        /// <returns>An IQueryable&lt;WorkoutIndexViewModel&gt; representing the projected results.</returns>
        public static IQueryable<WorkoutIndexViewModel> MakeProjectionToIndexViewModel(this IQueryable<Workout> workouts)
        {
            return workouts
                 .Select(w => new WorkoutIndexViewModel()
                 {
                     Id = w.Id,
                     Title = w.Title,
                     Date = w.Date,
                     Time = w.Time,
                     ImageUrl = w.ImageUrl,
                     BriefDescription = w.BriefDescription,
                     CategoryName = w.CategoryName,
                     MaxParticipants = w.MaxParticipants,
                     IsForBeginners = w.IsForBeginners,
                     AthleteId = w.AthleteId
                 });
        }

        /// <summary>
        /// Projects an IQueryable&lt;Workout&gt; to an IQueryable&lt;WorkoutDetailsViewModel&gt;,
        /// selecting specific properties including related Athlete information.
        /// </summary>
        /// <param name="workouts">The source IQueryable&lt;Workout&gt; to project from.</param>
        /// <returns>An IQueryable&lt;WorkoutDetailsViewModel&gt; representing the projected results.</returns>
        public static IQueryable<WorkoutDetailsViewModel> MakeProjectionToDetailsViewModel(this IQueryable<Workout> workouts)
        {
            return workouts
                .Select(w => new WorkoutDetailsViewModel()
                {
                    Id = w.Id,
                    Title = w.Title,
                    Date = w.Date,
                    Time = w.Time,
                    ImageUrl = w.ImageUrl,
                    BriefDescription = w.BriefDescription,
                    CategoryName = w.CategoryName,
                    MaxParticipants = w.MaxParticipants,
                    IsForBeginners = w.IsForBeginners,
                    CurrentParticipants = w.CurrentParticipants,
                    FullDescription = w.FullDescription,
                    AthleteId = w.AthleteId,
                    Athlete = new()
                    {
                        FirstName = w.Athlete.FirstName,
                        MiddleName = w.Athlete.MiddleName,
                        LastName = w.Athlete.LastName,
                        PhoneNumber = w.Athlete.PhoneNumber,
                    }
                });
        }
    }
}
