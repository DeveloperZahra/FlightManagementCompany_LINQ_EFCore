using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class CrewMember
    {
        // Primary Key for the CrewMember entity
        [Key]
        public int CrewId { get; set; } 

        // Full name of the crew member
        [Required]
        public string FullName { get; set; } // [cite: 26]

        // Role of the crew member (e.g., Pilot, CoPilot, FlightAttendant)
        [Required]
        public string Role { get; set; } // [cite: 27]

        // License number, nullable for non-pilot roles
        public string? LicenseNo { get; set; } // [cite: 28]

    }
}
