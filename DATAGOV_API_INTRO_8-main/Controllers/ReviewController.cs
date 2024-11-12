using Microsoft.AspNetCore.Mvc;
using DATAGOV_API_INTRO_8.Models;
using DATAGOV_API_INTRO_8.Services;
using System.Collections.Generic;

namespace YourWebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly DataService _dataService;

        // Inject DataService into the controller
        public ReviewsController(DataService dataService)
        {
            _dataService = dataService;
        }

        // Display list of reviews
        public IActionResult Index()
        {
            // Retrieve the list of reviews from DataService
            var reviews = _dataService.GetReviews();
            return View(reviews);
        }

        [HttpPost]
        public IActionResult SubmitReview(string name, int rating, string comment)
        {
            // Create a new review object
            var newReview = new Review
            {
                Id = _dataService.GetNextReviewId(), // Ensure unique ID is generated
                Name = name,
                Rating = rating,
                Comment = comment
            };

            // Save the review using DataService
            _dataService.AddReview(newReview);

            TempData["Message"] = "Thank you for your review!";
            return RedirectToAction("Index");
        }
    }
}
