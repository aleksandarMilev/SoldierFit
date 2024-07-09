namespace SoldierFit.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Attributes;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Exceptions;
    using SoldierFit.Core.Models.Workout;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;
    using static SoldierFit.Utilities.WebConstants;

    /// <summary>
    /// Controller responsible for managing workouts.
    /// </summary>
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;
        private readonly IAthleteService athleteService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkoutController"/> class.
        /// </summary>
        /// <param name="workoutService">The workout service.</param>
        /// <param name="athleteService">The athlete service.</param>
        public WorkoutController(
            IWorkoutService workoutService,
            IAthleteService athleteService)
        {
            this.workoutService = workoutService;
            this.athleteService = athleteService;
        }

        /// <summary>
        /// Retrieves the index page displaying past 3 and future 3 workouts.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pastModels = await workoutService.GetLastThreePastIndexViewModelsAsync();
            var presentModels = await workoutService.GetLastThreeFutureIndexViewModelsAsync();

            var model = new FutureAndPastWorkoutsViewModel()
            {
                PastWorkouts = pastModels,
                FutureWorkouts = presentModels,
            };

            string userId = this.User.GetId();
            this.ViewBag.CurrentAthleteId = await athleteService.GetAthleteIdAsync(userId);

            return View(model);
        }

        /// <summary>
        /// Retrieves the all workouts ordered by date and time of creating.
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> All()
            => this.View(await workoutService.GetAllIndexViewModelsAsync());


        /// <summary>
        /// Retrieves workouts created by the current athlete.
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> Mine()
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            var model = await workoutService.GetIndexViewModelsByAthleteIdAsync(athleteId.Value);

            return View(model);
        }

        /// <summary>
        /// Displays details of a specific workout.
        /// </summary>
        /// <param name="id">The ID of the workout to display.</param>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> Details(int id)
        {
            var model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId.HasValue)
            {
                ViewBag.CurrentAthleteId = athleteId.Value;
                ViewBag.AthleteIsParticipant = await athleteService.CurrentAthleteIsParticipant(id, athleteId.Value);
            }

            return View(model);
        }

        /// <summary>
        /// Displays the form to create a new workout.
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public IActionResult Create()
            => View(new CreateWorkoutViewModel());

        /// <summary>
        /// Handles the creation of a new workout.
        /// </summary>
        /// <param name="model">The data for the new workout.</param>
        [HttpPost]
        [AthleteAuthorization]
        public async Task<IActionResult> Create(CreateWorkoutViewModel model)
        {
            await ValidateCreateViewModelDateAndName(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            await workoutService.CreateAsync(model, athleteId.Value);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Displays the form to edit a workout.
        /// </summary>
        /// <param name="id">The ID of the workout to edit.</param>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId is null && !User.IsInRole(AdminRoleName))
            {
                return Unauthorized();
            }

            if (athleteId.HasValue)
            {
                if (model.AthleteId != athleteId)
                {
                    return Unauthorized();
                }
            }

            var editModel = new CreateWorkoutViewModel()
            {
                Title = model.Title,
                Date = model.Date,
                Time = model.Time,
                BriefDescription = model.BriefDescription,
                FullDescription = model.FullDescription,
                MaxParticipants = model.MaxParticipants,
                ImageUrl = model.ImageUrl,
                IsForBeginners = model.IsForBeginners,
                CategoryName = model.CategoryName
            };

            return View(editModel);
        }

        /// <summary>
        /// Handles the editing of a workout.
        /// </summary>
        /// <param name="id">The ID of the workout to edit.</param>
        /// <param name="model">The updated data for the workout.</param>
        [HttpPost]
        [AthleteAuthorization]
        public async Task<IActionResult> Edit(int id, CreateWorkoutViewModel model)
        {
            var workoutDetails = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId is null && !User.IsInRole(AdminRoleName))
            {
                return Unauthorized();
            }

            if (athleteId.HasValue)
            {
                if (workoutDetails!.AthleteId != athleteId)
                {
                    return Unauthorized();
                }
            }

            await ValidateCreateViewModelDateAndName(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await workoutService.EditAsync(id, model);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Displays the confirmation page to delete a workout.
        /// </summary>
        /// <param name="id">The ID of the workout to delete.</param>
		[HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> Delete(int id)
		{
            var model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId is null && !User.IsInRole(AdminRoleName))
            {
                return Unauthorized();
            }

            if (athleteId.HasValue)
            {
                if (model.AthleteId != athleteId)
                {
                    return Unauthorized();
                }
            }
            return View(model);
		}

        /// <summary>
        /// Handles the deletion of a workout.
        /// </summary>
        /// <param name="id">The ID of the workout to delete.</param>
        [HttpPost]
        [AthleteAuthorization]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
            var model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId is null && !User.IsInRole(AdminRoleName))
            {
                return Unauthorized();
            }

            if (athleteId.HasValue)
            {
                if (model.AthleteId != athleteId)
                {
                    return Unauthorized();
                }
            }

            await workoutService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

        /// <summary>
        /// Displays the success message after an athlete joins a workout.
        /// </summary>
        [HttpGet]
        public IActionResult JoinSuccess()
            => View();

        /// <summary>
        /// Handles the join action for a workout.
        /// </summary>
        /// <param name="workoutId">The ID of the workout to join.</param>
        [HttpPost]
        [AthleteAuthorization]
        public async Task<IActionResult> Join(int workoutId)
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            try
            {
                await workoutService.JoinAsync(workoutId, athleteId.Value);
            }
            catch (AlreadyJoinedException)
            {
                return View("AlreadyJoined");
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("spots"))
                {
                    return View("NoFreeSpotsLeft");
                }

                return View("WorkoutDoNotExist");
            }

            return RedirectToAction("JoinSuccess");
        }

        /// <summary>
        /// Retrieves all workouts where the current athlete is joined
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> JoinedWorkouts()
        {
            string userId = this.User.GetId();
            int? athleteId = await this.athleteService.GetAthleteIdAsync(userId);

            var model = await this.workoutService.GetIndexViewModelsWhereAthleteIsJoinedAsync(athleteId.Value);

            return this.View(model);
        }

        /// <summary>
        /// Displays the success message after an athlete leaves a workout.
        /// </summary>
        [HttpGet]
        public IActionResult LeaveSuccess()
            => View();

        /// <summary>
        /// Handles the leave action for a workout.
        /// </summary>
        /// <param name="workoutId">The ID of the workout to leave.</param>
        [HttpPost]
        [AthleteAuthorization]
        public async Task<IActionResult> Leave(int workoutId)
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            try
            {
                await workoutService.LeaveAsync(workoutId, athleteId.Value);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("does not exist"))
                {
                    return View("WorkoutDoNotExist");
                }

                return BadRequest();
            }

            return RedirectToAction("LeaveSuccess");
        }

        private async Task ValidateCreateViewModelDateAndName(CreateWorkoutViewModel model)
        {
            if (await workoutService.WorkoutWithSameNameExistsAsync(model.Title))
            {
                ModelState.AddModelError(nameof(model.Title), string.Format(WorkoutWithSameNameExists, model.Title));
            }

            if (!workoutService.WorkoutDateIsInRange(model.Date))
            {
                ModelState.AddModelError(nameof(model.Date), string.Format(InvalidDate, DateTime.Now.ToShortDateString(), DateTime.Now.AddMonths(1).ToShortDateString()));
            }

            if (!workoutService.WorkoutTimeIsAtLeastThreeHoursInFuture(model.Date, model.Time))
            {
                ModelState.AddModelError(nameof(model.Time), InvalidTime);
            }
        }
    }
}