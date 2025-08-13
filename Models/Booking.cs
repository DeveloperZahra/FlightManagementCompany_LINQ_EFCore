using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    public  class Booking
    {
        // Primary Key for the Booking entity
        [Key]
        public int BookingId { get; set; } 

        // Unique booking reference number
        [Required]
        public string BookingRef { get; set; } 

        // Date the booking was made
        [Required]
        public DateTime BookingDate { get; set; } 

        // Status of the booking
        [Required]
        public string Status { get; set; } 

    }
}
