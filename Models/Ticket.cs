using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add Ticket entity with properties, foreign keys, and baggage relationship
    public class Ticket
    {
        // Primary Key for the Ticket entity
        [Key]
        public int TicketId { get; set; } 

        // Seat number on the flight
        [Required]
        public string SeatNumber { get; set; }

        // Fare for the ticket
        [Required]
        
        [Column(TypeName = "decimal(18, 2)")] // Specify decimal precision 
        public decimal Fare { get; set; } 

        // Check-in status
        [Required]
        public bool Checkedin { get; set; }

        // Foreign Key to the Flight
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        // Foreign Key to the Booking
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booking booking { get; set; }

        // Navigation property for baggage associated with this ticket
        public ICollection<Baggage> Baggages { get; set; } = new List<Baggage>();

        
    }
}
