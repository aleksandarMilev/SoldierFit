namespace SoldierFit.Controllers
{
    using HouseRentingSystem.Attributes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Exceptions;
    using SoldierFit.Core.Models.Workout;
    using System.Security.Claims;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

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
        public WorkoutController(IWorkoutService workoutService, IAthleteService athleteService)
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
            IEnumerable<WorkoutIndexViewModel> pastModels = await workoutService.GetLastThreePastIndexViewModelsAsync();
            IEnumerable<WorkoutIndexViewModel> presentModels = await workoutService.GetLastThreeFutureIndexViewModelsAsync();

            FutureAndPastWorkoutsViewModel model = new()
            {
                PastWorkouts = pastModels,
                FutureWorkouts = presentModels,
            };

            ViewBag.CurrentAthleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            return View(model);
        }

        /// <summary>
        /// Retrieves workouts owned by the current athlete.
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public async Task<IActionResult> Mine()
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            IEnumerable<WorkoutIndexViewModel> model = await workoutService.GetIndexViewModelsByAthleteIdAsync(athleteId.Value);

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
            WorkoutDetailsViewModel? model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            ViewBag.CurrentAthleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            return View(model);
        }

        /// <summary>
        /// Displays the form to create a new workout.
        /// </summary>
        [HttpGet]
        [AthleteAuthorization]
        public IActionResult Create()
        {
            CreateWorkoutViewModel model = new();

            return View(model);
        }

        /// <summary>
        /// Handles the creation of a new workout.
        /// </summary>
        /// <param name="model">The data for the new workout.</param>
        [HttpPost]
        [AthleteAuthorization]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWorkoutViewModel model)
        {
            await ValdateCreateViewModelDateAndName(model);

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
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            WorkoutDetailsViewModel? model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            if (model!.AthleteId != athleteId.Value)
            {
                return Unauthorized();
            }

            CreateWorkoutViewModel editModel = new()
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
        [ValidateAntiForgeryToken]
        [AthleteAuthorization]
        public async Task<IActionResult> Edit(int id, CreateWorkoutViewModel model)
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            WorkoutDetailsViewModel? workoutDetails = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            if (workoutDetails!.AthleteId != athleteId)
            {
                return Unauthorized();
            }

            await ValdateCreateViewModelDateAndName(model);

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
			int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

			WorkoutDetailsViewModel? model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            if (model!.AthleteId != athleteId.Value)
			{
				return Unauthorized();
			}

			return View(model);
		}

        /// <summary>
        /// Handles the deletion of a workout.
        /// </summary>
        /// <param name="id">The ID of the workout to delete.</param>
        [HttpPost]
		[ValidateAntiForgeryToken]
        [AthleteAuthorization]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
			int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            WorkoutDetailsViewModel? model = await workoutService.GetDetailsViewModelByWorkoutIdAsync(id);

            if (model is null)
            {
                return View("WorkoutDoNotExist");
            }

            if (model!.AthleteId != athleteId.Value)
			{
				return Unauthorized();
			}

			await workoutService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

        [HttpGet]
        public IActionResult JoinSuccess()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            catch (InvalidOperationException)
            {
                return View("WorkoutDoNotExist");
            }

            return RedirectToAction("JoinSuccess");
        }

        private async Task ValdateCreateViewModelDateAndName(CreateWorkoutViewModel model)
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