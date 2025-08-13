using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Aircraft
    {
        // Primary Key for the Aircraft entity
        [Key]
        public int AircraftId { get; set; } 

        // Unique tail number of the aircraft
        [Required]
        public string TailNumber { get; set; } 

        // Model of the aircraft
        [Required]
        public string Model { get; set; } // [cite: 22]

        // Seating capacity of the aircraft
        [Required]
        public int Capacity { get; set; } // [cite: 23]
    }
}
