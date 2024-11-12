using Microsoft.AspNetCore.Mvc;

namespace YourWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContact(string name, string email, string phone, string subject, string message)
        {
            // Process the submitted data here (e.g., save to a database, send an email, etc.)
            ViewBag.Message = "Thank you for your message! We will get back to you soon.";

            // Redirect back to the Contact page with a success message
            return RedirectToAction("Index");
        }
    }
}
