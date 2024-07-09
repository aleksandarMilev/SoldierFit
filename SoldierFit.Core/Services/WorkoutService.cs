namespace SoldierFit.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Exceptions;
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
            => this.repository = repository;

        /// <inheritdoc/>
        public async Task<bool> ExistsByIdAsync(int id)
            => await this.repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Id == id);

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetAllIndexViewModelsAsync()
            => await this.repository
               .AllAsNoTracking<Workout>()
               .OrderBy(w => w.Date)
               .ThenBy(w => w.Time)
               .MakeProjectionToIndexViewModel()
               .ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastIndexViewModelsAsync()
            => await this.repository
               .AllAsNoTracking<Workout>()
               .Where(w =>
                    w.Date < DateTime.Now.Date ||
                    w.Date == DateTime.Now.Date && w.Time < DateTime.Now.TimeOfDay)
               .OrderByDescending(w => w.Date)
               .ThenByDescending(w => w.Time)
               .Take(3)
               .Reverse()
               .MakeProjectionToIndexViewModel()
               .ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureIndexViewModelsAsync() 
            => await this.repository
               .AllAsNoTracking<Workout>()
               .Where(w => 
                    w.Date > DateTime.Now.Date || 
                    w.Date == DateTime.Now.Date && w.Time > DateTime.Now.TimeOfDay)
               .OrderBy(w => w.Date)
               .ThenBy(w => w.Time)
               .Take(3)
               .MakeProjectionToIndexViewModel()
               .ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetIndexViewModelsByAthleteIdAsync(int id)
             => await this.repository
                .AllAsNoTracking<Workout>()
                .Where(w => w.AthleteId == id)
                .MakeProjectionToIndexViewModel()
                .ToListAsync();

        /// <inheritdoc/>
        public async Task<WorkoutDetailsViewModel?> GetDetailsViewModelByWorkoutIdAsync(int id)
            => await this.repository
                .AllAsNoTracking<Workout>()
                .MakeProjectionToDetailsViewModel()
                .FirstOrDefaultAsync(w => w.Id == id);
    
        

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

            await this.repository.AddAsync(workout);
            await this.repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task EditAsync(int workoutId, CreateWorkoutViewModel model)
        {
            Workout? workout = await this.repository.GetByIdAsync<Workout>(workoutId)
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

            await this.repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
		public async Task DeleteAsync(int workoutId)
        {
            var workout = await repository.GetByIdAsync<Workout>(workoutId)
                ?? throw new InvalidOperationException($"Workout with ID {workoutId} not found.");

            if (workout.CurrentParticipants > 0)
            {
                var athleteWorkout = await this.repository
                    .AllAsNoTracking<AthleteWorkout>()
                    .Where(aw => aw.WorkoutId == workout.Id)
                    .FirstOrDefaultAsync();

                this.repository.Delete(athleteWorkout!);
            }

            this.repository.Delete(workout);
            await this.repository.SaveChangesAsync();
        }


        /// <inheritdoc/>
        public async Task JoinAsync(int workoutId, int athleteId)
        {
            var workout = await this.repository.GetByIdAsync<Workout>(workoutId)
                ?? throw new InvalidOperationException($"Workout with ID: {workoutId} does not exist!");

            var athlete = await this.repository.GetByIdAsync<Athlete>(athleteId)
                ?? throw new InvalidOperationException($"Athlete with ID: {athleteId} does not exist!");

            var athleteWorkout = new AthleteWorkout { AthleteId = athleteId, WorkoutId = workoutId };

            bool athleteAlreadyJoined = await this.repository
                .AllAsNoTracking<AthleteWorkout>()
                .AnyAsync(aw => aw.AthleteId == athleteId && aw.WorkoutId == workoutId);

            if (athleteAlreadyJoined)
            {
                throw new AlreadyJoinedException("Athlete is already a participant in this workout.");
            }

            if (workout.CurrentParticipants == workout.MaxParticipants)
            {
                throw new InvalidOperationException("No more free spots left");
            }

            workout.CurrentParticipants++;

            await this.repository.AddAsync(athleteWorkout);
            await this.repository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task LeaveAsync(int workoutId, int athleteId)
        {
            var workout = await this.repository.GetByIdAsync<Workout>(workoutId)
                ?? throw new InvalidOperationException($"Workout with ID: {workoutId} does not exist!");

            var athlete = await this.repository.GetByIdAsync<Athlete>(athleteId)
                ?? throw new InvalidOperationException($"Athlete with ID: {athleteId} does not exist!");

            var athleteWorkout = await this.repository
                .AllAsNoTracking<AthleteWorkout>()
                .FirstOrDefaultAsync(aw => aw.AthleteId == athleteId && aw.WorkoutId == workoutId)
                ?? throw new InvalidOperationException();

            workout.CurrentParticipants--;

            this.repository.Delete(athleteWorkout);
            await this.repository.SaveChangesAsync();
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
            return await this.repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Title == title);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkoutIndexViewModel>> GetIndexViewModelsWhereAthleteIsJoinedAsync(int athleteId)
        {
            return await this.repository
                .AllAsNoTracking<AthleteWorkout>()
                .Where(aw => aw.AthleteId == athleteId)
                .OrderBy(aw => aw.Workout.Date)
                .ThenBy(aw => aw.Workout.Time)
                .MakeProjectionToIndexViewModel()
                .ToListAsync();
        }
    }
}