using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AirportId { get; set; } 

        // 3-letter IATA code, unique constraint required
        [Required]
        [StringLength(3)]
        public string IATA { get; set; } 

        // Name of the airport
        [Required]
        public string AirportName { get; set; } 

        // City where the airport is located
        [Required]
        public string City { get; set; } 

        // Country where the airport is located
        [Required]
        public string Country { get; set; } 

        // TimeZone of the airport
        [Required]
        public string TimeZone { get; set; }

        //This property represents all routes where the current airport is the origin

       [InverseProperty("OriginAirport")]
        public ICollection<Route> OriginRoute { get; set; } = new List<Route>(); //corresponds to the "OriginAirport" navigation property in the Route entity


        //This property represents all routes where the current airport is the destination.
        [InverseProperty("DistenationAirport")]
        public ICollection<Route> DistenationRoute { get; set; } = new List<Route>(); //  the "DestinationAirport" navigation property in the Route entity


    }
}

