using Microsoft.AspNetCore.Mvc;
using DATAGOV_API_INTRO_8.Services;

namespace YourWebApp.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly DataService _dataService;

        // Inject DataService into the controller
        public AnalyticsController(DataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            // Retrieve data from DataService for analytics
            var bookings = _dataService.GetBookings();
            var reviews = _dataService.GetReviews();

            // Calculate analytics data
            var analyticsData = new
            {
                TotalBookings = bookings.Count,
                AverageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0,
                CustomerSatisfaction = "89%" // Placeholder, can be calculated or updated based on actual data
            };

            ViewBag.AnalyticsData = analyticsData;
            return View();
        }
    }
}
