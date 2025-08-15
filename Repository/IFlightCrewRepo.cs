using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages FlightCrew entities.
    /// It specifies the core data access operations (CRUD) for the FlightCrew model,
    /// which represents the many-to-many relationship between Flights and CrewMembers.
    public interface IFlightCrewRepo
    {
        void AddFlightCrew(FlightCrew flightCrew);//Adds a new flight crew association to the underlying data store
        void DeleteFlightCrew(int id);//Adds a new flight crew association to the underlying data store
        IEnumerable<FlightCrew> GetAllFlightCrews();
        FlightCrew GetFlightCrewById(int id);
        void UpdateFlightCrew(FlightCrew flightCrew);
    }
}