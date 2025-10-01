namespace ThAmCo.Venues.DTOs
{
    public class ReservationDTO
    {
        public string Reference { get; set; }
        public DateTime EventDate { get; set; }
        public string VenueCode { get; set; }
        public DateTime WhenMade { get; set; }
        public string StaffId { get; set; }
        // Optionally: public AvailabilityDTO Availability { get; set; }
    }
}