namespace SoldierFit.Core.Services
{
	using Microsoft.EntityFrameworkCore;
	using SoldierFit.Core.Contracts;
	using SoldierFit.Core.Models.Workout;
	using SoldierFit.Infrastructure.Common;
	using SoldierFit.Infrastructure.Data.Models;
	using System.Collections.Generic;

	public class WorkoutService : IWorkoutService
    {
        private readonly IRepository repository;

        public WorkoutService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastWorkoutsAsync()
        {
            return await repository
               .AllAsNoTracking<Workout>()
               .Where(w => w.Date < DateTime.Now)
               .OrderBy(w => w.Date)
               .Take(3)
               .Select(w => new WorkoutIndexViewModel()
               {
                   Id = w.Id,
                   Title = w.Title,
                   Date = w.Date,
                   Description = w.Description,
                   ImageUrl = w.ImageUrl
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureWorkoutsAsync()
		{ 
			return await repository
               .AllAsNoTracking<Workout>()
               .Where(w => w.Date > DateTime.Now)
               .OrderBy(w => w.Date)
               .Take(3)
               .Select(w => new WorkoutIndexViewModel()
               {
	               Id = w.Id,
	               Title = w.Title,
	               Date = w.Date,
	               Description = w.Description,
	               ImageUrl = w.ImageUrl
               })
               .ToListAsync();
		}
	}
}
