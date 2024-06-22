namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Workout;

    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService service;

        public WorkoutController(IWorkoutService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var pastModels = await service.GetLastThreePastWorkoutsAsync();
            var presentModels = await service.GetLastThreeFutureWorkoutsAsync();

            var model = new WorkoutsSummaryViewModel
            {
                PastWorkouts = pastModels,
                FutureWorkouts = presentModels,
            };

			return View(model);
        }
    }
}
