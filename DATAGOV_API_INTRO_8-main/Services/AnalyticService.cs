using System.Collections.Generic;
using System.Linq;
using DATAGOV_API_INTRO_8.Models;

namespace DATAGOV_API_INTRO_8.Services
{
    public class AnalyticService
    {
        // In-memory list to store park data
        private readonly List<Analytic> ParksList = new List<Analytic>();

        // Flag to track if API data has been fetched
        private bool isDataFetched = false;

        // Method to check if the data has been fetched from the API
        public bool IsDataFetched() => isDataFetched;

        // Method to mark data as fetched
        public void MarkDataAsFetched() => isDataFetched = true;

        // Method to check if the list is empty
        public bool IsParksListEmpty() => ParksList.Count == 0;

        // Method to add parks to the list
        public void AddParks(List<Analytic> parks)
        {
            ParksList.AddRange(parks);
        }

        // Create: Add a new park
        public void AddPark(Analytic park)
        {
            ParksList.Add(park);
        }

        // Read: Get all parks
        public List<Analytic> GetAllParks()
        {
            return ParksList;
        }

        // Read: Get a specific park by ID
        public Analytic GetParkById(string id)
        {
            return ParksList.FirstOrDefault(p => p.id == id);
        }

        // Update: Update a specific park by ID
        public bool UpdatePark(string id, Analytic updatedPark)
        {
            var existingPark = ParksList.FirstOrDefault(p => p.id == id);
            if (existingPark != null)
            {
                existingPark.fullName = updatedPark.fullName;
                existingPark.parkCode = updatedPark.parkCode;
                existingPark.description = updatedPark.description;
                existingPark.latLong = updatedPark.latLong;
                return true;
            }
            return false;
        }

        // Delete: Remove a specific park by ID
        public bool DeletePark(string id)
        {
            var park = ParksList.FirstOrDefault(p => p.id == id);
            if (park != null)
            {
                ParksList.Remove(park);
                return true;
            }
            return false;
        }
    }
}
