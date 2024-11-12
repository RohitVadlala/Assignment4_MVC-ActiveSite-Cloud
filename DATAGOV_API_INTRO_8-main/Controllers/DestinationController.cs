using Microsoft.AspNetCore.Mvc;
using DATAGOV_API_INTRO_8.Models;
using DATAGOV_API_INTRO_8.Services;
using System.Collections.Generic;

namespace YourWebApp.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly DataService _dataService;

        // Inject DataService into the controller
        public DestinationsController(DataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            // Retrieve the list of destinations from DataService
            var destinations = _dataService.GetDestinations();
            return View(destinations);
        }
    }
}
