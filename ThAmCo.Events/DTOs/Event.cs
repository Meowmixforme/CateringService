using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.DTOs
{
    public class EventDTO
    {
        public EventDTO() { }

        public EventDTO(string id, string Title, TimeSpan Duration, DateTime Date, string EventTypeId)
        {

        }


        public int Id { get; set; }

        public string Title { get; set; }


        // How long the event runs for
        [Column(TypeName = "bigint")]
        public TimeSpan? Duration { get; set; }

        public DateTime Date { get; set; }

        public string EventTypeId { get; set; }

        public ICollection<GuestBooking> Bookings { get; set; }



        public string VenueReservationReference { get; set; }

        public ICollection<Staffing> Staff { get; set; }

        //If the event has been cancelled
        public bool Cancelled { get; set; }

        //Catering menu for event
        public int FoodBookingId { get; set; }
    }
}
