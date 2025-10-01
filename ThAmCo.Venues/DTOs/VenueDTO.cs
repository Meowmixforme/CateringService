namespace ThAmCo.Venues.DTOs
{
    public class VenueDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        // Optionally: public List<EventTypeShortDTO> SuitableEventTypes { get; set; }
        // Optionally: public List<AvailabilityDTO> AvailableDates { get; set; }
    }
}
