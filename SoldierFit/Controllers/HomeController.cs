namespace SoldierFit.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoldierFit.Models;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index() 
            => View();

        [AllowAnonymous]
        public IActionResult Privacy()
            =>  View();

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
