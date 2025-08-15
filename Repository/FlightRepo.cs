using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
   // This repository class handles all data access operations for the Flight entity.
/// It provides a connection to the database context to perform these operations.
    public class FlightRepo
    {
        // A private, read-only field to hold the database context.
        // This is the bridge between the application's models and the database
        private readonly FlightDbContext _context;

       // Initializes a new instance of the FlightRepo class.
    /// This constructor receives the database context via dependency injection
        public FlightRepo(FlightDbContext context)
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
            if (flight != null)  // Checks if the flight was found before attempting to delete it
            {
                _context.Flights.Remove(flight);  // Removes the entity from the context.
                _context.SaveChanges();
            }
        }
    }
}
