using System.Collections.Generic;
using System.Linq;
using DATAGOV_API_INTRO_8.Models;

namespace DATAGOV_API_INTRO_8.Services
{
    public class DataService
    {
        // In-memory storage for destinations, reviews, and bookings
        private List<Destination> _destinations;
        private List<Review> _reviews;
        private List<Booking> _bookings;

        public DataService()
        {
            // Initialize the lists with some sample data
            _destinations = new List<Destination>
            {
                new Destination { Id = 1, Name = "Paris", Country = "France", Price = 1200, Description = "City of Love" },
                new Destination { Id = 2, Name = "Rome", Country = "Italy", Price = 1100, Description = "Eternal City" }
            };

            _reviews = new List<Review>
            {
                new Review { Id = 1, Name = "Alice", Rating = 5, Comment = "Amazing trip!" },
                new Review { Id = 2, Name = "Bob", Rating = 4, Comment = "Great experience." }
            };

            _bookings = new List<Booking>
            {
                new Booking { Id = 1, Destination = "Paris", Date = DateTime.Parse("2024-06-15"), Travelers = 2, Status = "Confirmed" }
            };
        }

        // Methods to access and manipulate the data

        public List<Destination> GetDestinations() => _destinations;

        public Destination GetDestinationById(int id) => _destinations.FirstOrDefault(d => d.Id == id);

        public void AddDestination(Destination destination)
        {
            destination.Id = _destinations.Max(d => d.Id) + 1;
            _destinations.Add(destination);
        }

        public List<Booking> GetBookings() => _bookings;

        public void AddBooking(Booking booking)
        {
            booking.Id = _bookings.Max(b => b.Id) + 1;
            _bookings.Add(booking);
        }

        public List<Review> GetReviews() => _reviews;

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public int GetNextReviewId()
        {
            return _reviews.Count > 0 ? _reviews.Max(r => r.Id) + 1 : 1;
        }
    }
}
