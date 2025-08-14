using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //A concrete implementation of the IAircraftRepo interface using Entity Framework Core.
/// It handles data access for the Aircraft entity
    public class AircraftRepo : IAircraftRepo
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

        // This method updates an existing aircraft entity in the database.
        public void UpdateAircraft(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            _context.SaveChanges();
        }

        // This method deletes an aircraft from the database by its ID.
        public void DeleteAircraft(int AircraftId)
        {
            var aircraft = _context.Aircrafts.Find(AircraftId); //First, it finds the aircraft by its ID.
            if (aircraft != null) //  It checks if the aircraft exists before attempting to remove it.
            {
                _context.Aircrafts.Remove(aircraft);
                _context.SaveChanges();
            }
        }
    }
}
