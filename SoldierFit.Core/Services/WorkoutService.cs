namespace SoldierFit.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Workout;
    using SoldierFit.Infrastructure.Common;
    using SoldierFit.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Data;
	using System.Net;

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
               .Where(w => w.Date.Date < DateTime.Now.Date)
               .OrderBy(w => w.Date)
               .Take(3)
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
                   IsForBeginners = w.IsForBeginners
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureWorkoutsAsync()
		{ 
			return await repository
               .AllAsNoTracking<Workout>()
               .Where(w => w.Date.Date >= DateTime.Now.Date)
               .OrderBy(w => w.Date)
               .Take(3)
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
                   IsForBeginners = w.IsForBeginners
               })
               .ToListAsync();
		}

        public async Task<bool> WorkoutWithSameNameExistsAsync(string title)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Title == title);
        }

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

        public bool WorkoutDateIsInRange(DateTime date)
        {
            DateTime today = DateTime.Now.Date;
            DateTime maxDate = today.AddMonths(1);

            return date >= today && date <= maxDate;
        }

        public bool WorkoutTimeIsAtLeastThreeHoursInFuture(DateTime date, TimeSpan time)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime workoutDateTime = date.Date + time;

            return workoutDateTime >= currentDateTime.AddHours(3);
        }

        public async Task<IEnumerable<WorkoutIndexViewModel>> GetWorkoutsByUserId(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .Where(w => w.AthleteId == id)
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
                    IsForBeginners = w.IsForBeginners
                })
                .ToListAsync();
        }

        public async Task<WorkoutDetailsViewModel?> GetWorkoutById(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
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
                })
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository
                .AllAsNoTracking<Workout>()
                .AnyAsync(w => w.Id == id);
        }

        public async Task EditAsync(int workoutId, CreateWorkoutViewModel model)
        {
            Workout? workout = await repository.GetbyIdAsync<Workout>(workoutId)
                ?? throw new NullReferenceException("There is not such workout!");

            if (workout != null)
            {
                workout.Title = model.Title;
                workout.Date = model.Date;
                workout.Time = model.Time;
                workout.BriefDescription = model.BriefDescription;
                workout.FullDescription = model.FullDescription;
                workout.MaxParticipants = model.MaxParticipants;
                workout.ImageUrl = model.ImageUrl;
                workout.IsForBeginners = model.IsForBeginners;
                workout.CategoryName = model.CategoryName;
            }

            await repository.SaveChangesAsync();
        }
    }
}
