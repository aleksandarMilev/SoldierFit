namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Athlete;
    using System.Security.Claims;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class AthleteController : BaseController
    {
        private readonly IAthleteService service;

        public AthleteController(IAthleteService service)
        {
            this.service = service;   
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await service.ExistByIdAsync(User.GetId()))
            {
                return View("AlreadyAthlete");
            }

            BecomeAthleteFormModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAthleteFormModel model)
        {
            if (await service.UserWithPhoneExistsAlready(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExistsMessage);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.CreateAsync(
                model.FirstName,
                model.MiddleName,
                model.LastName,
                model.Age,
                model.Email,
                model.PhoneNumber,
                User.GetId());

            return RedirectToAction("Index", "Workout");
        }
    }
}
