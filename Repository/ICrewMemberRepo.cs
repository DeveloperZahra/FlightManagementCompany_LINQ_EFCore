using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages CrewMember entities.
/// It specifies the core data access operations (CRUD) for the CrewMember model.
    public interface ICrewMemberRepo
    {
        void AddCrewMember(CrewMember crewMember);// Adds a new crew member to the underlying data store
        void DeleteCrewMember(int CrewId);//Deletes a crew member from the data store based on their unique ID
        IEnumerable<CrewMember> GetAllCrewMembers(); //Retrieves all crew members from the data store
        CrewMember GetCrewMemberById(int CrewId); //Retrieves a single crew member by their unique ID.
        void UpdateCrewMember(CrewMember crewMember);
    }
}