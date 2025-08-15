using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages FlightCrew entities.
    /// It specifies the core data access operations (CRUD) for the FlightCrew model,
    /// which represents the many-to-many relationship between Flights and CrewMembers.
    public interface IFlightCrewRepo
    {
        void AddFlightCrew(FlightCrew flightCrew);//Adds a new flight crew association to the underlying data store
        void DeleteFlightCrew(int id);//Deletes a flight crew association from the data store based on its unique ID
        IEnumerable<FlightCrew> GetAllFlightCrews();//Retrieves all flight crew associations from the data store.
        FlightCrew GetFlightCrewById(int id);//Retrieves a single flight crew association by its unique ID
        void UpdateFlightCrew(FlightCrew flightCrew);// Updates an existing flight crew association record in the data store
    }
}