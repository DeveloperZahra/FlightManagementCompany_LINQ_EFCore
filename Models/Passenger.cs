using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public class Passenger
    {
        // Primary Key for the Passenger entity
        [Key]
        public int PassengerId { get; set; } 

        // Full name of the passenger
        [Required]
        public string FullName { get; set; } // [cite: 41]

        // Unique passport number
        [Required]
        public string PassportNo { get; set; } // [cite: 42]

        // Nationality of the passenger
        [Required]
        public string Nationality { get; set; } // [cite: 43]

        // Date of Birth
        [Required]
        public DateTime DOB { get; set; } // [cite: 44]
    }
}
