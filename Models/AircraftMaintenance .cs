using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add AircraftMaintenance entity with properties and aircraft relationship
    public class AircraftMaintenance
    {
        // Primary Key for the Maintenance entity
        [Key]
        public int MaintenanceId { get; set; } 

        // Date of maintenance
        [Required]
        public DateTime MaintenanceDate { get; set; } 

        // Type of maintenance (e.g., A-Check, B-Check)
        [Required]
        public string Type { get; set; } 

        // Notes on the maintenance performed
        public string? Notes { get; set; }

        // Foreign Key to the Aircraft
        public int AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }

    }
}
