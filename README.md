# Flight Management Company

  ## 📜Project Summary: 
  Build a Flight Management System (FMS) backend for a company that manages flights, aircraft, crews, bookings, 
passengers and airports — implemented using layered architecture, EF Core, Repository pattern, and LINQ.

##   🎯Learning Goals: 
• Design and document an ERD and relational schema. 

• Implement EF Core models with annotations and relationships. 

• Implement layered architecture: Presentation / Service / Repository / Data (DbContext). 

• Implement per-entity repositories exposing essential CRUD + query methods. 

• Write LINQ queries: joins, groupings, aggregations, partitioning, projection to DTOs, hierarchical queries


 ## 🗂️ Business Domain & ERD (entities + relationships):

 ### 1) Entities (core): 

☑️ Airport 

• AirportId (int PK) 

• IATA (string, 3, unique) 

• Name (string) 

• City (string) 

• Country (string) 

• TimeZone (string) 

☑️ Aircraft 

• AircraftId (int PK) 

• TailNumber (string, unique) 

• Model (string) 

• Capacity (int) 

☑️ CrewMember 

• CrewId (int PK) 

• FullName (string) 

• Role (enum/string) — Pilot/CoPilot/FlightAttendant 

• LicenseNo (string, nullable) 
 
☑️ Route 

• RouteId (int PK) 

• DistanceKm (int) 

☑️ Flight 

• FlightId (int PK) 

• FlightNumber (string) — e.g., "FM101"

• DepartureUtc (DateTime) 

• ArrivalUtc (DateTime) 

• Status (string/enum) 

• Note: add unique constraint on (FlightNumber, DepartureUtc.Date) 

☑️ Passenger 

• PassengerId (int PK) 

• FullName (string) 

• PassportNo (string, unique) 

• Nationality (string) 

• DOB (DateTime) 

☑️ Booking 

• BookingId (int PK) 

• BookingRef (string, unique) 

• BookingDate (DateTime) 

• Status (string) 

☑️ Ticket 

• TicketId (int PK) 

• SeatNumber (string) 

• Fare (decimal) 

• CheckedIn (bool) 

☑️ FlightCrew ➔ relationship attributes on many to many 

• RoleOnFlight (string) 

• Primary Key (FlightId, CrewId) 
 
☑️ Baggage 

• BaggageId (int PK) 

• TicketId (FK → Ticket) 

• WeightKg (decimal) 

• TagNumber (string) 

☑️ AircraftMaintenance 

• MaintenanceId (int PK) 

• MaintenanceDate (DateTime) 

• Type (string) 

• Notes (string)

### 2) ERD 

![](image/FlightManagementCompany-ERD.png)


### 3) Mapping 

![](image/FlightManagementCompany-Mapping.png)

### 3) Normlization 

**Step 1**  — First Normal Form (1NF) Becouse of the following reasons, the database is already in 1NF:

Each table has a primary key.
Each column contains atomic values.
No repeating groups are visible.

**Step 2** — Second Normal Form (2NF) The database is already in 2NF because:

All non-key attributes are fully functionally dependent on the primary key.
There are no partial dependencies of any column on the primary key.
All non-key attributes are dependent on the entire primary key.
There are no transitive dependencies.

**Step 3** — Third Normal Form (3NF) The database is already in 3NF because:

There are no transitive dependencies.
All non-key attributes are dependent only on the primary key.

### 📊What are Data Transfer Objects (DTOs)?

DTO stands for Data Transfer Object. It is a design pattern used in programming applications to simplify the process of transferring data between different layers of an application, such as transferring data from the database layer to the front-end layer or vice versa.

Simply put, a DTO is an object (class) that contains only properties and no behaviors or business logic. Its primary purpose is to group data into a single object to facilitate its sending and receiving across a network or between layers.


### Why use DTOs in C# projects? 🤔

Using DTOs has several benefits, especially in projects that use a layered architecture, such as an airline flight management system project:

Separation of Concerns: DTOs separate database models (such as Aircraft or Flight) from models exposed to the user via an API. This prevents internal database details from being leaked to the API.

Performance Improvement: DTOs allow you to choose only the properties you need. For example, instead of sending all the properties of a Passenger object to the front-end, you can create a PassengerDto that contains only FullName and PassportNo, reducing the amount of data transferred.

Data Hiding: You can control the data displayed to the user. If a CrewMember object contains a Salary field, you can create a CrewMemberDto that doesn't contain this field to protect sensitive information.

Preventing Over-Posting Attacks: When you use DTOs for API inputs, you ensure that the user can only submit the data you specify in the DTO, preventing the possibility of unauthorized field updates.

### 📖Examples from the current project "Flight Management Company" demonstrate the importance of using DTOs:

🏷️ RouteRevenueDto: Combines data from the Route and Flight entities to show route revenue.

🏷️ CrewConflictDto: Used to display information about a potential conflict in a flight crew table, combining data from the CrewMember object and the Flight object.

🏷️ PassengerItineraryDto: Combines passenger information with details of their flight itinerary.

❗These examples demonstrate that DTOs are not only used to represent a single entity, but also to create custom models that combine data from multiple different entities to meet specific API requirements.

### 📖Code example demonstrating the use of DTOs:

Let's say we want to create an endpoint in our API that displays flight information and crew details. Instead of returning the entire Flight and CrewMember objects, we can create a custom DTO containing only the required information.

**1. Create DTOs:**

```sql
// A DTO to represent crew member information. It does not include sensitive fields such as the license number.
public class CrewMemberDto
{
public int CrewId { get; set; }
public string FullName { get; set; }
public string Role { get; set; }
}

// A DTO to represent flight details. It includes a list of CrewMemberDto.
public class FlightDetailsDto
{
public int FlightId { get; set; }
public string FlightNumber { get; set; }
public DateTime DepartureUtc { get; set; }
public DateTime ArrivalUtc { get; set; }
public string Status { get; set; }
public string OriginAirportIATA { get; set; }
public string DestinationAirportIATA { get; set; }
public List<CrewMemberDto> Crew { get; set; }
}
```

**2. Using DTOs in the Repository Layer:**

Although object transformation logic is typically performed in the Service Layer, LINQ can be used in the Repository Layer to retrieve only the required data, improving performance.


```sql 
// Inside FlightRepo
public async Task<FlightDetailsDto> GetFlightDetailsById(int flightId)
{
// Using LINQ to include associated entities and aggregate data into a DTO
var flight = await _context.Flights
.Include(f => f.Route)
.Include(f => f.FlightCrews)
.ThenInclude(fc => fc.CrewMember)
.Where(f => f.FlightId == flightId)
.Select(f => new FlightDetailsDto
{
FlightId = f.FlightId,
FlightNumber = f.FlightNumber,
DepartureUtc = f.DepartureUtc,
ArrivalUtc = f.ArrivalUtc,
Status = f.Status,
OriginAirportIATA = f.Route.OriginAirport.IATA, 
DestinationAirportIATA = f.Route.DestinationAirport.IATA, 
Crew = f.FlightCrews.Select(fc => new CrewMemberDto 
{ 
CrewId = fc.CrewMember.CrewId, 
FullName = fc.CrewMember.FullName, 
Role = fc. RoleOnFlight 
}).ToList() 
}) 
.FirstOrDefaultAsync(); 

return flight;
}
```
**3. Using DTOs in an API Controller:**

Here, the controller calls a repository function that returns the DTO directly, then displays it as a response to the client request.

```sql 
// Inside FlightController
[HttpGet("{id}")]
public async Task<IActionResult> GetFlight(int id)
{
// Call the repository function that returns the DTO
var flightDetails = await _flightRepo.GetFlightDetailsById(id);

if (flightDetails == null)
{
return NotFound(); // Return 404 if the flight was not found
}

return Ok(flightDetails); // Return the DTO as a JSON response
}
```

### 📝Summary:
This code demonstrates how DTOs can be used to separate the internal data model from the external API. Instead of returning EF Core objects, which may contain circular references or sensitive data, a simple, custom DTO is returned containing only the data the client needs.

