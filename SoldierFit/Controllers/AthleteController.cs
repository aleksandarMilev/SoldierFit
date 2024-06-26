namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Core.Contracts;
    using SoldierFit.Core.Models.Athlete;
    using System.Security.Claims;
    using static SoldierFit.Infrastructure.Constants.MessageConstants;

    /// <summary>
    /// Controller responsible for managing athlete-related operations.
    /// </summary>
    public class AthleteController : BaseController
    {
        private readonly IAthleteService service;
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AthleteController"/> class.
        /// </summary>
        /// <param name="service">The athlete service.</param>
        /// <param name="userManager">The user manager service.</param>
        public AthleteController(IAthleteService service, UserManager<IdentityUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }


        /// <summary>
        /// GET: Displays the form to become an athlete.
        /// </summary>
        /// <returns>The view for becoming an athlete.</returns>
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

        /// <summary>
        /// POST: Handles the submission of the form to become an athlete.
        /// </summary>
        /// <param name="model">The form model containing athlete details.</param>
        /// <returns>Redirects to the Workout index if successful; otherwise, redisplays the form with errors.</returns>
        [HttpPost]
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
                user.UserName,
                User.GetId());

            return RedirectToAction("Index", "Workout");
        }
    }
}