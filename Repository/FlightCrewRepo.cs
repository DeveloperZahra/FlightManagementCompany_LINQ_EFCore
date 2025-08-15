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

        // Retrieve all flight crew assignments
        public IEnumerable<FlightCrew> GetAll()
        {
            return _context.FlightCrews.ToList();
        }

        // Retrieve a flight crew assignment by ID
        public FlightCrew GetById(int id)
        {
            return _context.FlightCrews.Find(id);
        }
    }
}
