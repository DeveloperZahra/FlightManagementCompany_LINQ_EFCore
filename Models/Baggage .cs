using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Baggage
    {
        // Primary Key for the Baggage entity
        [Key]
        public int BaggageId { get; set; } 

    }
}
