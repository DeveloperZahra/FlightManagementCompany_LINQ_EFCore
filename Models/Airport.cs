using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add Airport entity with properties and navigation routes
    public class Airport
    {
        // Primary Key for the Airport entity
        [Key]
        public int AirportId { get; set; } // [cite: 13]

        // 3-letter IATA code, unique constraint required
        [Required]
        [StringLength(3)]
        public string IATA { get; set; } // [cite: 14]

        // Name of the airport
        [Required]
        public string AirportName { get; set; } // [cite: 15]

        // City where the airport is located
        [Required]
        public string City { get; set; } // [cite: 16]

        // Country where the airport is located
        [Required]
        public string Country { get; set; } // [cite: 17]

        // TimeZone of the airport
        [Required]
        public string TimeZone { get; set; } // [cite: 18]

        // Navigation properties for relationships
        public ICollection<Route> OriginRoutes { get; set; }
        public ICollection<Route> DestinationRoutes { get; set; }
    }
}

