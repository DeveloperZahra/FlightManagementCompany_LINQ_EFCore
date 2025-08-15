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

        // Initializes a new instance of the FlightCrewRepo class.
        /// This constructor is typically used by a dependency injection container
        public FlightCrewRepo(FlightDbContext context)
        {
            _context = context;
        }

        //// Retrieves all flight records from the database
        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.ToList(); // Accesses the Flights DbSet and retrieves all records, returning them as a list.
        }

        // Retrieves a single flight by its unique ID
        public Flight GetFlightById(int FlightId)
        {
            return _context.Flights.Find(FlightId);// Uses the efficient Find() method to look up the flight by its primary key.
        }

        //  Adds a new flight record to the database
        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);// Adds the new entity to the context.
            _context.SaveChanges();
        }

        // Updates an existing flight record in the database
        public void UpdateFlight(Flight flight)
        {
            _context.Flights.Update(flight);   // Marks the entity as updated
            _context.SaveChanges();
        }

         // Deletes a flight record from the database by its ID.
        public void DeleteFlight(int FlightId)
        {
            var flight = _context.Flights.Find(FlightId); // Finds the flight record by its ID.
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
        }
    }
}
