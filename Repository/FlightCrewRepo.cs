using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Flight entity.
/// It provides methods for performing CRUD operations on flight records.
/// Note: The class name is "FlightCrewRepo" but the methods manage the "Flight" entity.
    public class FlightCrewRepo
    {
        // A private, read-only field to hold the database context.
        // This context is the bridge between the application's models and the database.
        private readonly FlightDbContext _context;

        public FlightCrewRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all flights
        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights].ToList(); 
        }

        // Retrieve a flight by ID
        public Flight GetFlightById(int FlightId)
        {
            return _context.Flights.Find(FlightId);
        }

        // Add a new flight
        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        // Update an existing flight
        public void UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }

        // Delete a flight by ID
        public void DeleteFlight(int FlightId)
        {
            var flight = _context.Flights.Find(FlightId);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
        }
    }
}
