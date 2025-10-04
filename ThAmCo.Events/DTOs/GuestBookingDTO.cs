namespace ThAmCo.Events.DTOs
{
    public class GuestBookingDTO
    {
        public int EventId { get; set; }
        public int GuestId { get; set; }
        public bool Attended { get; set; }
    }
}