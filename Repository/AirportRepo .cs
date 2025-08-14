using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
   // This repository class handles all data access operations for the Airport entity.
/// It implements the core CRUD (Create, Read, Update, Delete) functionality
    public class AirportRepo
    {
        
            private readonly FlightDbContext _context;

            public AirportRepo(FlightDbContext context)
            {
                _context = context;
            }

            // Retrieve all airports from the database
            public IEnumerable<Airport> GetAllAirports()
            {
                return _context.Airports.ToList();
            }

            // Retrieve a single airport by ID
            public Airport GetAirportById(int AirportId)
            {
                return _context.Airports.Find(AirportId);
            }

            // Add a new airport to the database
            public void AddAirport(Airport airport)
            {
                _context.Airports.Add(airport);
                _context.SaveChanges();
            }

            // Update an existing airport in the database
            public void UpdateAirport(Airport airport)
            {
                _context.Airports.Update(airport);
                _context.SaveChanges();
            }

            // Delete an airport by ID
            public void DeleteAirport(int AirportId)
            {
                var airport = _context.Airports.Find(AirportId);
                if (airport != null)
                {
                    _context.Airports.Remove(airport);
                    _context.SaveChanges();
                }
            }
        }
}
