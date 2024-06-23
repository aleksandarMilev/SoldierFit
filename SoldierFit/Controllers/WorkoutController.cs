namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Workout;
    using System.Security.Claims;

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
            var pastModels = await workoutService.GetLastThreePastWorkoutsAsync();
            var presentModels = await workoutService.GetLastThreeFutureWorkoutsAsync();

            var model = new WorkoutsSummaryViewModel
            {
                PastWorkouts = pastModels,
                FutureWorkouts = presentModels,
            };

			return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateWorkoutViewModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutViewModel model)
        {
            if (await workoutService.WorkoutWithSameNameExistsAsync(model.Title))
            {
                ModelState.AddModelError(nameof(model.Title), "");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int? athleteId = await athleteService.GetAthleteIdAsync(User.GetId());

            if (athleteId == null)
            {
                return View("NotAnAthlete");
            }

            await workoutService.CreateAsync(
                model.Title,
                model.Date,
                model.Time,
                model.Description,
                model.ImageUrl,
                athleteId.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
