using Microsoft.AspNetCore.Mvc;
using TaskDelegationSystem.Attributes;

namespace TaskDelegationSystem.NewFolder
{
    public class HomeController : Controller
    {
        [JwtAuthorize]
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [JwtAuthorize]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Error()
        {
            return View("Error");
        }        
    }
}
