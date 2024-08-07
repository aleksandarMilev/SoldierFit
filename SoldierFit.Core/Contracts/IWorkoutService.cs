﻿namespace SoldierFit.Core.Contracts
{
    using SoldierFit.Core.Models.Workout;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Service interface for managing workouts.
    /// </summary>
    public interface IWorkoutService
    {
        /// <summary>
        /// Checks if a workout with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the workout.</param>
        /// <returns>True if a workout with the ID exists; otherwise, false.</returns>
        Task<bool> ExistsByIdAsync(int id);



        /// <summary>
        /// Retrieves the last three past workouts.
        /// </summary>
        /// <returns>A collection of <see cref="WorkoutIndexViewModel"/> representing the last three past workouts.</returns>
        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreePastIndexViewModelsAsync();

        /// <summary>
        /// Retrieves the last three future workouts.
        /// </summary>
        /// <returns>A collection of <see cref="WorkoutIndexViewModel"/> representing the last three future workouts.</returns>
        Task<IEnumerable<WorkoutIndexViewModel>> GetLastThreeFutureIndexViewModelsAsync();

        /// <summary>
        /// Retrieves workouts associated with a specific athlete ID.
        /// The collection may be empty if no workouts are associated with the provided athlete ID.
        /// </summary>
        /// <param name="id">The ID of the athlete.</param>
        /// <returns>A collection of <see cref="WorkoutIndexViewModel"/> associated with the athlete ID.</returns>
        Task<IEnumerable<WorkoutIndexViewModel>> GetIndexViewModelsByAthleteIdAsync(int id);

        /// <summary>
        /// Retrieves detailed information about a workout by its ID.
        /// </summary>
        /// <param name="id">The ID of the workout.</param>
        /// <returns>A <see cref="WorkoutDetailsViewModel"/> representing the workout details, or null if not found.</returns>
        Task<WorkoutDetailsViewModel?> GetDetailsViewModelByWorkoutIdAsync(int id);

        /// <summary>
        /// Retrieves workouts where an athlete has joined based on the athlete's ID.
        /// </summary>
        /// <param name="athleteId">The ID of the athlete.</param>
        /// <returns>A collection of <see cref="WorkoutIndexViewModel"/> representing the workouts where the athlete has joined.</returns>
        Task<IEnumerable<WorkoutIndexViewModel>> GetIndexViewModelsWhereAthleteIsJoinedAsync(int athleteId);

        /// <summary>
        /// Retrieves all workouts as <see cref="WorkoutIndexViewModel"/>.
        /// </summary>
        /// <returns>A collection of <see cref="WorkoutIndexViewModel"/> representing all workouts.</returns>
        Task<IEnumerable<WorkoutIndexViewModel>> GetAllIndexViewModelsAsync();




        /// <summary>
        /// Creates a new workout. Sets CurrentParticipants to 0.
        /// </summary>
        /// <param name="model">The data model for creating a workout.</param>
        /// <param name="athleteId">The ID of the athlete associated with the workout.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task CreateAsync(CreateWorkoutViewModel model, int athleteId);

        /// <summary>
        /// Edits an existing workout identified by its ID.
        /// </summary>
        /// <param name="workoutId">The ID of the workout to edit.</param>
        /// <param name="model">The updated data model for the workout.</param>
        /// <exception cref="InvalidOperationException">Thrown if no workout with the specified ID exists.</exception>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task EditAsync(int workoutId, CreateWorkoutViewModel model);

        /// <summary>
        /// Deletes a workout by its ID.
        /// </summary>
        /// <param name="workoutId">The ID of the workout to delete.</param>
        /// <exception cref="InvalidOperationException">Thrown if no workout with the specified ID exists.</exception>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task DeleteAsync(int workoutId);



        /// <summary>
        /// Allows an athlete to join a workout.
        /// </summary>
        /// <param name="athleteId">The identifier of the athlete who wants to join the workout.</param>
        /// <param name="workoutId">The identifier of the workout the athlete wants to join.</param>
        /// <returns>A task that represents the asynchronous join operation.</returns>
        Task JoinAsync(int athleteId, int workoutId);

        /// <summary>
        /// Remove the athlete from the workout joined.
        /// </summary>
        /// <param name="athleteId">The identifier of the athlete who wants to be removed from the workout.</param>
        /// <param name="workoutId">The identifier of the workout the athlete wants to leave.</param>
        /// <returns>A task that represents the asynchronous leave operation.</returns>
        Task LeaveAsync(int workoutId, int athleteId);



        /// <summary>
        /// Checks if a given workout date is within a valid range.
        /// </summary>
        /// <param name="date">The date of the workout.</param>
        /// <returns>True if the date is within the valid range (today to one month ahead); otherwise, false.</returns>
        bool WorkoutDateIsInRange(DateTime date);

        /// <summary>
        /// Checks if a given workout time is at least three hours in the future.
        /// </summary>
        /// <param name="date">The date of the workout.</param>
        /// <param name="time">The time of the workout.</param>
        /// <returns>True if the time is at least three hours in the future from the current time; otherwise, false.</returns>
        bool WorkoutTimeIsAtLeastThreeHoursInFuture(DateTime date, TimeSpan time);

        /// <summary>
        /// Checks if a workout with the same title already exists in the database.
        /// </summary>
        /// <param name="title">The title of the workout to check.</param>
        /// <returns>True if a workout with the same title exists; otherwise, false.</returns>
        Task<bool> WorkoutWithSameNameExistsAsync(string title);
    }
}
