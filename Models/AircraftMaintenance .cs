using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
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
        public string? Notes { get; set; } // [cite: 67]

    }
}
