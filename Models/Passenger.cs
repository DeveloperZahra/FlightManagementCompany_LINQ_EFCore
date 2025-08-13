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
        public string P_F_Name { get; set; }

        [Required]
        public string P_L_Name { get; set; }

        // Unique passport number
        [Required]
        public string PassportNo { get; set; } 

        // Nationality of the passenger
        [Required]
        public string Nationality { get; set; } 

        // Date of Birth
        [Required]
        public DateTime DOB { get; set; }
    }
}
