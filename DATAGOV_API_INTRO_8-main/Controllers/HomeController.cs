using Microsoft.AspNetCore.Mvc;
using DATAGOV_API_INTRO_8.Services;
using DATAGOV_API_INTRO_8.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace DATAGOV_API_INTRO_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataService _dataService;
        private readonly AnalyticService _analyticService;
        private readonly HttpClient _httpClient;

        static string BASE_URL = "https://serpapi.com/";
        static string API_KEY =  "4260cd9538177ed71f495ab03d652cff0d50699de087dd382aedad8eb91f7c1a";

        

        public HomeController(DataService dataService)
        {
            _dataService = dataService;
            _httpClient = new HttpClient();
        }


         [HttpGet]
        public async Task<IActionResult> GetTopSightsData(string destination)
        {
            try
            {
                string apiUrl = $"https://serpapi.com/search.json?engine=google&q={destination}+Destinations&api_key={API_KEY}";
                
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return Json(new { success = true, data = jsonResponse });
                }
                return Json(new { success = false, error = "Failed to fetch data" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

    // Add this method to serve the destination analytics view
        public IActionResult DestinationAnalytics()
        {
            ViewBag.Countries = new List<string> { "Italy", "France", "Spain", "Netherlands", "Switzerland" };
            return View();
        }

        public IActionResult Index()
        {
            var featuredDestinations = _dataService.GetDestinations().Take(4).ToList();
            ViewData["FeaturedDestinations"] = featuredDestinations;
            return View();
        }

        public IActionResult Destinations()
        {
            return View(_dataService.GetDestinations());
        }

        public IActionResult Reviews()
        {
            return View(_dataService.GetReviews());
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                _dataService.AddReview(review);
                return RedirectToAction("Reviews");
            }
            return View("Reviews", _dataService.GetReviews());
        }

        public IActionResult Analytics()
        {
            var bookingCount = _dataService.GetBookings().Count;
            var averageRating = _dataService.GetReviews().Any() ? _dataService.GetReviews().Average(r => r.Rating) : 0;

            ViewData["BookingCount"] = bookingCount;
            ViewData["AverageRating"] = averageRating;

            return View();
        }

        public IActionResult Details(int id)
        {
            var destination = _dataService.GetDestinationById(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}