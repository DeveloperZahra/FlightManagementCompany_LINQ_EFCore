using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class is responsible for all data access operations related to
/// the AircraftMaintenance entity
    public class AircraftMaintenanceRepo
    {
        private readonly FlightDbContext _context;

        public AircraftMaintenanceRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all maintenance records
        public IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance()
        {
            return _context.AircraftMaintenances.ToList();
        }

        // Retrieve a maintenance record by ID
        public AircraftMaintenance GetAircraftMaintenanceById(int MaintenanceId)
        {
            return _context.AircraftMaintenances.Find(MaintenanceId);
        }

        // Add a new maintenance record
        public void AddAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Add(maintenance);
            _context.SaveChanges();
        }

        // Update an existing maintenance record
        public void UpdateAircraftMaintenance(AircraftMaintenance maintenance)
        {
            _context.AircraftMaintenances.Update(maintenance);
            _context.SaveChanges();
        }

        // Delete a maintenance record by ID
        public void DeleteAircraftMaintenance(int MaintenanceId)
        {
            var maintenance = _context.AircraftMaintenances.Find(MaintenanceId);
            if (maintenance != null)
            {
                _context.AircraftMaintenances.Remove(maintenance);
                _context.SaveChanges();
            }
        }
    }
}
