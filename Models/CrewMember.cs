using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add CrewMember entity with properties and flight crew relationship
    public class CrewMember
    {
        // Primary Key for the CrewMember entity
        [Key]
        public int CrewId { get; set; }

        // Full name of the crew member
        [Required]
        public string M_F_Name { get; set; }

        [Required]
        public string M_L_Name { get; set; }

        // Role of the crew member (e.g., Pilot, CoPilot, FlightAttendant)
        [Required]
        public string CrewRole { get; set; }

        // License number, nullable for non-pilot roles
        public string? LicenseNo { get; set; }

        // Navigation property for the many-to-many relationship with flights
        public ICollection<FlightCrew> FlightCrews { get; set; } = new List<FlightCrew>();

    
    // Enum for crew roles

    public enum CrewRole
    {
        Pilot,
        CoPilot,
        FlightAttendant
    }

}
}
