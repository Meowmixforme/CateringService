namespace ThAmCo.Events.Models.Event
{
    public class EventDeleteViewModel
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }

        public DateTime Date { get; set; }

        public string TypeId { get; set; }

        public bool Cancelled { get; set; }

        //Venues
        public string VenuesReservation { get; set; }
    }
}
