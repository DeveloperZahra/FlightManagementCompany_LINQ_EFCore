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

        // City of origin
        [Required]
        public int OriginCity { get; set; }

        //City of destination
        [Required]
        public string DestinationCity { get; set; }


        // Navigation property for related flights
        public ICollection<Flight> Flights { get; set; }

        // Navigation property for Airport
        public ICollection<Airport> Airports { get; set; }
    }
}
