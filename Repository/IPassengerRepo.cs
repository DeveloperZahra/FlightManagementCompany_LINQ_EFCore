using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
   // This interface defines the contract for a repository that manages Passenger entities.
/// It specifies the core data access operations (CRUD) for the Passenger model.
    public interface IPassengerRepo
    {
        void Addpassenger(Passenger passenger);//Adds a new passenger to the underlying data store
        void Deletepassenger(int PassengerId);//Deletes a passenger from the data store based on their unique ID
        IEnumerable<Passenger> GetAllPassengers();//Retrieves all passengers from the data store.
        Passenger GetpassengerById(int PassengerId);
        void UpdatePassenger(Passenger passenger);
    }
}