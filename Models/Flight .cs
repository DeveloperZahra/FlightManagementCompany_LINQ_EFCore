using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add Flight entity with properties, foreign keys, and relationships
    public class Flight
    {
        // Primary Key for the Flight entity
        [Key]
        public int FlightId { get; set; } 

        // Flight number (e.g., "FM101")
        [Required]
        public string FlightNumber { get; set; } 

        // Departure time in UTC
        [Required]
        public DateTime DepartureUtc { get; set; } 

        // Arrival time in UTC
        [Required]
        public DateTime ArrivalUtc { get; set; } 

        // Current status of the flight
        [Required]
        public string Status { get; set; }


        // Foreign Key to the Route
        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public Route Route { get; set; }

        // Foreign Key to the Aircraft
        public int AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }


        // collection navigation to aircraft
        public Aircraft Aircrafts { get; set; }

        // navigation property to route
        public Route Routes { get; set; } // Navigation property to Route



        // Navigation property for the many-to-many relationship with crew
        public ICollection<FlightCrew> FlightCrews { get; set; }

        // Navigation property for tickets on this flight
        public ICollection<Ticket> Tickets { get; set; }
    }
}
