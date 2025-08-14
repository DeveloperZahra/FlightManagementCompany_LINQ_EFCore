using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ICrewMemberRepo
    {
        void AddCrewMember(CrewMember crewMember);
        void DeleteCrewMember(int CrewId);
        IEnumerable<CrewMember> GetAllCrewMembers();
        CrewMember GetCrewMemberById(int CrewId);
        void UpdateCrewMember(CrewMember crewMember);
    }
}