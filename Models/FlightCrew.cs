using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class FlightCrew
    {
       // Composite Primary Key 
        public int FlightId { get; set; }
        public int CrewId { get; set; }

        // Foreign Key to Flight
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}
