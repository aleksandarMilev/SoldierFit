﻿namespace SoldierFit.Core.Services
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
               .Where(w => w.Date.Date < DateTime.Now.Date)
               .OrderBy(w => w.Date)
               .Take(3)
               .Select(w => new WorkoutIndexViewModel()
               {
                   Id = w.Id,
                   Title = w.Title,
                   Date = w.Date,
                   BriefDescription = w.BriefDescription,
                   ImageUrl = w.ImageUrl
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
	               BriefDescription = w.BriefDescription,
	               ImageUrl = w.ImageUrl
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
    }
}
