using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class is responsible for all data access operations related to
/// the CrewMember entity. It provides methods for performing CRUD operations.
    public class CrewMemberRepo
    {
        private readonly FlightDbContext _context;

        public CrewMemberRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all crew members
        public IEnumerable<CrewMember> GetAllCrewMembers()
        {
            return _context.CrewMembers.ToList();
        }

        // Retrieve a crew member by ID
        public CrewMember GetCrewMemberById(int CrewId)
        {
            return _context.CrewMembers.Find(CrewId);
        }

        // Add a new crew member
        public void AddCrewMember(CrewMember crewMember)
        {
            _context.CrewMembers.Add(crewMember);
            _context.SaveChanges();
        }

        // Update an existing crew member
        public void UpdateCrewMember(CrewMember crewMember)
        {
            _context.CrewMembers.Update(crewMember);
            _context.SaveChanges();
        }

        // Delete a crew member by ID
        public void DeleteCrewMember(int CrewId)
        {
            var crewMember = _context.CrewMembers.Find(CrewId);
            if (crewMember != null)
            {
                _context.CrewMembers.Remove(crewMember);
                _context.SaveChanges();
            }
        }
    }
}
