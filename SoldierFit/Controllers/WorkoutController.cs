namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Workout;
    using System.Security.Claims;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;
        private readonly IAthleteService athleteService;

        public WorkoutController(IWorkoutService workoutService, IAthleteService athleteService)
        {
            this.workoutService = workoutService;
            this.athleteService = athleteService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<WorkoutIndexViewModel> pastModels = await workoutService.GetLastThreePastWorkoutsAsync();
            IEnumerable<WorkoutIndexViewModel> presentModels = await workoutService.GetLastThreeFutureWorkoutsAsync();

            FutureAndPastWorkoutsViewModel model = new()
            {
                PastWorkouts = pastModels,
                FutureWorkouts = presentModels,
            };

			return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId == null)
            {
                return View("NotAnAthlete");
            }

            CreateWorkoutViewModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutViewModel model)
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId == null)
            {
                return View("NotAnAthlete");
            }

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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await workoutService.CreateAsync(model, athleteId.Value);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId == null)
            {
                return View("NotAnAthlete");
            }

            IEnumerable<WorkoutIndexViewModel> model = await workoutService.GetWorkoutsByUserId(athleteId.Value);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId == null)
            {
                return View("NotAnAthlete");
            }

            if (!await workoutService.ExistsByIdAsync(id))
            {
                return View("WorkoutDoNotExist");
            }

            WorkoutDetailsViewModel? model = await workoutService.GetWorkoutById(id);

            return View(model);
        }
    }
}