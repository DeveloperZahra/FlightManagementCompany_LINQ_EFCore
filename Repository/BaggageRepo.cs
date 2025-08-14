using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    //This repository class handles all data access operations for the Baggage entity.
/// It provides methods for performing CRUD operations on baggage records
    public class BaggageRepo
    {
        // A private, read-only field to hold the database context.
        // This context is the entry point to the database for this repository
        private readonly FlightDbContext _context;

        //Initializes a new instance of the BaggageRepo class
        public BaggageRepo(FlightDbContext context)
        {
            _context = context;
        }

        // Retrieve all baggage records from the database
        public IEnumerable<Baggage> GetAllBaggages()
        {
            return _context.Baggages.ToList();
        }

        // Retrieves all baggage records from the database
        public Baggage GetBaggageById(int BaggageId)
        {
            return _context.Baggages.Find(BaggageId);
        }

        // Add a new baggage record to the database
        public void AddBaggage(Baggage baggage)
        {
            _context.Baggages.Add(baggage);
            _context.SaveChanges();
        }

        // Update an existing baggage record
        public void UpdateBaggage(Baggage baggage)
        {
            _context.Baggages.Update(baggage);
            _context.SaveChanges();
        }

        // Delete a baggage record by ID
        public void DeleteBaggage(int BaggageId)
        {
            var baggage = _context.Baggages.Find(BaggageId);
            if (baggage != null)
            {
                _context.Baggages.Remove(baggage);
                _context.SaveChanges();
            }
        }
    }
}
