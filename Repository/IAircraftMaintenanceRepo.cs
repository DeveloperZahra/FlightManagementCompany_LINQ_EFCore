using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages AircraftMaintenance entities.
/// It specifies the core data access operations (CRUD) for the AircraftMaintenance model.
    public interface IAircraftMaintenanceRepo
    {
        void AddAircraftMaintenance(AircraftMaintenance maintenance);
        void DeleteAircraftMaintenance(int MaintenanceId);
        AircraftMaintenance GetAircraftMaintenanceById(int MaintenanceId);
        IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance();
        void UpdateAircraftMaintenance(AircraftMaintenance maintenance);
    }
}