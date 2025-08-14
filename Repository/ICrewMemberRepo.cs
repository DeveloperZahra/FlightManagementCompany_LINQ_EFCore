using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    //This interface defines the contract for a repository that manages CrewMember entities.
/// It specifies the core data access operations (CRUD) for the CrewMember model.
    public interface ICrewMemberRepo
    {
        void AddCrewMember(CrewMember crewMember);// Adds a new crew member to the underlying data store
        void DeleteCrewMember(int CrewId);
        IEnumerable<CrewMember> GetAllCrewMembers();
        CrewMember GetCrewMemberById(int CrewId);
        void UpdateCrewMember(CrewMember crewMember);
    }
}