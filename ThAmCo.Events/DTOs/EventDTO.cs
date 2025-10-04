namespace ThAmCo.Events.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTime Date { get; set; }
        public string EventTypeId { get; set; }
        public bool Cancelled { get; set; }
        public int FoodBookingId { get; set; }
        public string VenueReservationReference { get; set; }  // <-- Add this line
        // Optionally:
        // public List<GuestBookingDTO> Bookings { get; set; }
        // public List<StaffingDTO> StaffBookings { get; set; }
    }
}