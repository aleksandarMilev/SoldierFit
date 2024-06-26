namespace HouseRentingSystem.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SoldierFit.Controllers;
    using SoldierFit.Core.Contracts;
    using System.Security.Claims;


    /// <summary>
    /// Custom authorization attribute to check if the current user is an athlete.
    /// </summary>
    public class AthleteAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAthleteService? service = context.HttpContext.RequestServices.GetService<IAthleteService>();

            if (service == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (service != null && !service.ExistByIdAsync(context.HttpContext.User.GetId()).Result)
            {
                context.Result = new RedirectToActionResult(nameof(AthleteController.Become), "Athlete", null);
            }
        }
    }
}