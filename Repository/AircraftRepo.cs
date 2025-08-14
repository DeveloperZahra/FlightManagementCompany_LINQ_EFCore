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

        public AircraftRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all aircrafts from the database
        public IEnumerable<Aircraft> GetAll()
        {
            return _context.Aircrafts.ToList();
        }

        // Retrieve a single aircraft by ID
        public Aircraft GetAircraftById(int AircraftId)
        {
            return _context.Aircrafts.Find(AircraftId);
        }

        // Add a new aircraft to the database
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
