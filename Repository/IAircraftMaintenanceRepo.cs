using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages AircraftMaintenance entities.
/// It specifies the core data access operations (CRUD) for the AircraftMaintenance model.
    public interface IAircraftMaintenanceRepo
    {
        void AddAircraftMaintenance(AircraftMaintenance maintenance);//Adds a new aircraft maintenance record to the underlying data store
        void DeleteAircraftMaintenance(int MaintenanceId); //Deletes an aircraft maintenance record from the data store based on its unique ID.
        AircraftMaintenance GetAircraftMaintenanceById(int MaintenanceId); //Retrieves a single aircraft maintenance record by its unique ID
        IEnumerable<AircraftMaintenance> GetAllAircraftMaintenance();
        void UpdateAircraftMaintenance(AircraftMaintenance maintenance);
    }
}