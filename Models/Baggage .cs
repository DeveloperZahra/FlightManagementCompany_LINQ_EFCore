using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Models
{
    //Add Baggage entity with properties and ticket relationship
    public class Baggage
    {
        // Primary Key for the Baggage entity
        [Key]
        public int BaggageId { get; set; }


        // Weight of the baggage in kilograms
        [Required]
        
        [Column(TypeName = "decimal(18, 2)")] // Specify decimal precision 
        public decimal WeightKg { get; set; }


        // Unique tag number for the baggage
        [Required]
        public string TagNumber { get; set; }


        // Foreign Key to the Ticket
        public int TicketId { get; set; } 
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
