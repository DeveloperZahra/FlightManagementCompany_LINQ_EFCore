using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
   // Add Route entity with properties and navigation relationships
    public class Route
    {
        // Primary Key for the Route entity
        [Key]
        public int RouteId { get; set; } 

        // Distance in kilometers
        [Required]
        public int DistanceKm { get; set; }

        [Required]
        public int OriginAirportId { get; set; } // Foriegn key to airport

        [Required]
        public int DestinationAirportId { get; set; } // Foriegn key to airport


        // navigation to origin airport
        [InverseProperty("OriginRoute")]
        public Airport OriginAirport { get; set; }

        // navigation to Destination airport
        [InverseProperty("DistenationRoute")]
        public Airport DistenationAirport { get; set; }

        // Navigation property for Flight
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();

    }
}
