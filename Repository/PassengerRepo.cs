using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Passenger entity.
    /// It provides a connection to the database context to perform these operations
    public class PassengerRepo : IPassengerRepo
    {
        // A private, read-only field to hold the database context.
        // This is the bridge between the application's models and the database
        private readonly FlightDbContext _context;

        //Initializes a new instance of the PassengerRepository class.
        /// This constructor receives the database context via dependency injection
        public PassengerRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all passengers
        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _context.Passengers.ToList();
        }

        // Retrieve a passenger by ID
        public Passenger GetpassengerById(int PassengerId)
        {
            return _context.Passengers.Find(PassengerId);
        }

        // Add a new passenger
        public void Addpassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }

        // Update an existing passenger
        public void UpdatePassenger(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
        }

        // Delete a passenger by ID
        public void Deletepassenger(int PassengerId)
        {
            var passenger = _context.Passengers.Find(PassengerId);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
        }

    }
}
