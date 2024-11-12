using Microsoft.AspNetCore.Mvc;

namespace YourWebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
