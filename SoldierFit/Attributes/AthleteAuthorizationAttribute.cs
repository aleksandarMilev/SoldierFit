namespace SoldierFit.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SoldierFit.Controllers;
    using SoldierFit.Core.Contracts;
    using System.Security.Claims;
    using static SoldierFit.Utilities.WebConstants;


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

            if (service != null &&
                !service.ExistByIdAsync(context.HttpContext.User.GetId()).Result &&
                !context.HttpContext.User.IsInRole(AdminRoleName))
            {
                context.Result = new RedirectToActionResult(nameof(AthleteController.Become), "Athlete", null);
            }
        }
    }
}