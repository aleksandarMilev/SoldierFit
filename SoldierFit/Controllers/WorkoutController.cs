namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models;

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
            IEnumerable<WorkoutDto> models;

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                models = await service.AllWorkoutsAsync();
            }
            else
            {
                models = await service.LastThreeWorkoutsAsync();
            }

            return View(models);
        }
    }
}
