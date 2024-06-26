namespace SoldierFit.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Extensions;
    using SoldierFit.Core.Models.Workout;
    using SoldierFit.Infrastructure.Common;
    using SoldierFit.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Data;

    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository repository;

        /// <summary>
        /// Service implementation for managing workouts.
        /// </summary>
        public WorkoutService(IRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Id == id);
        }



        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastIndexViewModelsAsync()
        {
            return await repository
               .AllAsNoTracking<Workout>()
               .Where(w => w.Date.Date < DateTime.Now.Date)
               .OrderBy(w => w.Date)
               .Take(3)
               .MakeProjectionToIndexViewModel()
               .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureIndexViewModelsAsync()
        {
            return await repository
               .AllAsNoTracking<Workout>()
               .Where(w => w.Date.Date >= DateTime.Now.Date)
               .OrderBy(w => w.Date)
               .Take(3)
               .MakeProjectionToIndexViewModel()
               .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetIndexViewModelsByAthleteIdAsync(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .Where(w => w.AthleteId == id)
                .MakeProjectionToIndexViewModel()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<WorkoutDetailsViewModel?> GetDetailsViewModelByWorkoutIdAsync(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .MakeProjectionToDetailsViewModel()
                .FirstOrDefaultAsync(w => w.Id == id);
        }



        /// <inheritdoc/>
        public async Task CreateAsync(CreateWorkoutViewModel model, int athleteId)
        {
            Workout workout = new()
            {
                Title = model.Title,
                Date = model.Date,
                Time = model.Time,
                BriefDescription = model.BriefDescription,
                FullDescription = model.FullDescription,
                ImageUrl = model.ImageUrl,
                CategoryName = model.CategoryName,
                IsForBeginners = model.IsForBeginners,
                MaxParticipants = model.MaxParticipants,
                CurrentParticipants = 0,
                AthleteId = athleteId
            };

            await repository.AddAsync(workout);
            await repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task EditAsync(int workoutId, CreateWorkoutViewModel model)
        {
            Workout? workout = await repository.GetByIdAsync<Workout>(workoutId)
                ?? throw new InvalidOperationException($"Workout with ID {workoutId} not found.");

            workout.Title = model.Title;
            workout.Date = model.Date;
            workout.Time = model.Time;
            workout.BriefDescription = model.BriefDescription;
            workout.FullDescription = model.FullDescription;
            workout.MaxParticipants = model.MaxParticipants;
            workout.ImageUrl = model.ImageUrl;
            workout.IsForBeginners = model.IsForBeginners;
            workout.CategoryName = model.CategoryName;

            await repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
		public async Task DeleteAsync(int workoutId)
		{
            Workout? workout = await repository.GetByIdAsync<Workout>(workoutId)
                ?? throw new InvalidOperationException($"Workout with ID {workoutId} not found.");

            repository.Delete(workout);
			await repository.SaveChangesAsync();
		}



        /// <inheritdoc/>
        public bool WorkoutDateIsInRange(DateTime date)
        {
            DateTime today = DateTime.Now.Date;
            DateTime maxDate = today.AddMonths(1);

            return date >= today && date <= maxDate;
        }

        /// <inheritdoc/>
        public bool WorkoutTimeIsAtLeastThreeHoursInFuture(DateTime date, TimeSpan time)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime workoutDateTime = date.Date + time;

            return workoutDateTime >= currentDateTime.AddHours(3);
        }

        /// <inheritdoc/>
        public async Task<bool> WorkoutWithSameNameExistsAsync(string title)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Title == title);
        }
    }
}
