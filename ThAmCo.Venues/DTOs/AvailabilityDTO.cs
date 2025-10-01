namespace ThAmCo.Venues.DTOs
{
    public class AvailabilityDTO
    {
        public DateTime Date { get; set; }
        public string VenueCode { get; set; }
        public double CostPerHour { get; set; }
        // Optionally: public VenueShortDTO Venue { get; set; }
        // Optionally: public ReservationDTO Reservation { get; set; }
    }
}
