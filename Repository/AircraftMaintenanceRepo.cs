using FlightManagementCompany.Models;
using FlightManagementCompany_LINQ_EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class is responsible for all data access operations related to
    /// the AircraftMaintenance entity
    public class AircraftMaintenanceRepo : IAircraftMaintenanceRepo
    {
        // A private, read-only field to hold the database context. This is injected
        // through the constructor and used to interact with the database
        private readonly FlightDbContext _context;

        //Initializes a new instance of the AircraftMaintenanceRepo class
        public AircraftMaintenanceRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieves all maintenance records from the database
        public IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance()
        {
            return _context.AircraftMaintenances.ToList(); // Accesses the AircraftMaintenances DbSet from the context and returns
                                                           // all records as a list
        }

        // Retrieves a single maintenance record by its unique ID
        public AircraftMaintenance GetAircraftMaintenanceById(int MaintenanceId)
        {
            return _context.AircraftMaintenances.Find(MaintenanceId);  // The Find() method is used for efficient lookup by primary key
        }

        // Adds a new aircraft maintenance record to the database
        public void AddAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Add(maintenance); // Adds the new entity to the context's tracking system.
            _context.SaveChanges(); // Commits the changes to the database.
        }

        // Updates an existing aircraft maintenance record in the database
        public void UpdateAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Update(maintenance); // Marks the entity as updated so EF Core knows to modify it
            _context.SaveChanges();
        }

        //  Deletes an aircraft maintenance record from the database by its ID
        public void DeleteAircraftMaintenance(int MaintenanceId)
        {
            var maintenance = _context.AircraftMaintenances.Find(MaintenanceId); // First, find the record to be deleted
            if (maintenance != null)  // If the record exists, remove it and save changes
            {
                _context.AircraftMaintenances.Remove(maintenance);
                _context.SaveChanges();
            }
        }
    }
}
