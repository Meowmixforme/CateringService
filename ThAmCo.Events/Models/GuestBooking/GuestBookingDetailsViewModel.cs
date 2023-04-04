
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThAmCo.Events.Models.Event;
using ThAmCo.Events.Models.Guest;

namespace ThAmCo.Events.Models.GuestBooking
{
    public class GuestBookingDetailsViewModel
    {

        [Key, Column(Order = 0)]
        public int EventId {get; set;}

        public EventDetailsViewModel Event { get; set; }

        [Key, Column(Order = 1)]
        public int GuestId { get; set;}

        public GuestDetailsViewModel Guest { get; set;}

        public bool Attended { get; set; }
    }
}
