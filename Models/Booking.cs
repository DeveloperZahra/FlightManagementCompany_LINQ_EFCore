using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // Foreign Key to the Passenger
        public int PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }


        // Navigation property for tickets in this booking
        public ICollection<Ticket> Tickets { get; set; }
    }
}
