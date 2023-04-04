using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        public Event() { }

        public Event(string id, string Title, DateTime Duration, DateTime Date, String EventTypeId) {
        
        }


        public int Id { get; set; }

        public string Title { get; set; }


        // How long the event runs for
        [Column(TypeName = "bigint")]
        public TimeSpan? Duration { get; set; }

        public DateTime Date { get; set; }

        public string EventTypeId { get; set; }

        public List<GuestBooking> Bookings { get; set;}

        public string VenueReservationReference { get; set; }

        public List<Staffing> StaffBooking { get; set; }

        //If the event has been cancelled
        public bool Cancelled { get; set; }

        public int CateringMenu { get; set; }
    }
}
