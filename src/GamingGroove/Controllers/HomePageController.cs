using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GamingGroove.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {           
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "FeedPage");
            }
            return View();
        }
    }
}    