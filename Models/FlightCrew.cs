using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    // Junction table for the many-to-many Flight-Crew relationship
    public class FlightCrew
    {
       // Composite Primary Key 
        public int FlightId { get; set; }
        public int CrewId { get; set; }

        // Foreign Key to Flight
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }


        // Foreign Key to CrewMember
        [ForeignKey("CrewId")]
        public CrewMember CrewMember { get; set; }


        // Role of the crew member on this specific flight
        [Required]
        public string RoleOnFlight { get; set; }


        public Flight Flights { get; set; } // Navigation property to Flight

        public CrewMember CrewMember { get; set; } // Navigation property to CrewMember
    }
}
