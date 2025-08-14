using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class AircraftRepo
    {
        // Private field to hold the database context.
        // The FlightDbContext is used to interact with the database
        private readonly FlightDbContext _context;

        // Constructor for the AircraftRepo class.
        /// Initializes the repository with a database context
        public AircraftRepo(FlightDbContext context)
        {
            _context = context;
        }
        // This method retrieves all aircrafts from the database and returns them as a list.
        // Retrieve all aircrafts from the database
        public IEnumerable<Aircraft> GetAllAircraft()
        {
            return _context.Aircrafts.ToList(); // Accesses the Aircrafts DbSet from the context and converts it to a list.
        }

        // Retrieve a single aircraft by its primary key ID
        public Aircraft GetAircraftById(int AircraftId)
        {
            return _context.Aircrafts.Find(AircraftId);
        }

        // This method adds a new aircraft entity to the database.
        public void AddAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            _context.SaveChanges();
        }

        // Update an existing aircraft in the database
        public void UpdateAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            _context.SaveChanges();
        }

        // Delete an aircraft by ID
        public void DeleteAircraft(int AircraftId)
        {
            var aircraft = _context.Aircrafts.Find(AircraftId);
            if (aircraft != null)
            {
                _context.Aircrafts.Remove(aircraft);
                _context.SaveChanges();
            }
        }
    }
}
