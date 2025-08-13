using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Route
    {
        // Primary Key for the Route entity
        [Key]
        public int RouteId { get; set; } 

        // Distance in kilometers
        [Required]
        public int DistanceKm { get; set; }

        // Foreign Key for the origin airport
        public int AirportId { get; set; }

        // Navigation property for the origin airport
        [ForeignKey("AirportId")]
        public Airport Airports { get; set; }


    }
}
