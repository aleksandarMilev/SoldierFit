namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Athlete;
    using System.Security.Claims;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    public class AthleteController : BaseController
    {
        private readonly IAthleteService service;
        private readonly UserManager<IdentityUser> userManager;

        public AthleteController(IAthleteService service, UserManager<IdentityUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
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
                ModelState.AddModelError(nameof(model.PhoneNumber), string.Format(PhoneExistsMessage, model.PhoneNumber));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityUser user = await userManager.GetUserAsync(User);

            await service.CreateAsync(
                model.FirstName,
                model.MiddleName,
                model.LastName,
                model.Age,
                model.PhoneNumber,
                user.Email,
                User.GetId());

            return RedirectToAction("Index", "Workout");
        }
    }
}
