using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    }
}
