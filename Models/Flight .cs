using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
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
        public string Status { get; set; } // [cite: 37]
    }
}
