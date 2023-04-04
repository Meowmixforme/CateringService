using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    public class GuestBooking
    {

        public GuestBooking()
        {

        }

        public GuestBooking(int eventId, Event eventt, int guestId, Guest guest, bool attended)
        {
            EventId = eventId;
            Event = eventt;
            GuestId = guestId;
            Guest = guest;
            Attended = attended;
        }

        [Key, Column(Order = 0)]
        public int EventId { get; set; }

        public Event Event { get; set; }


        [Key, Column(Order = 1)]
        public int GuestId { get; set; }

        public Guest Guest { get; set; }

 
        // To see register attendance
        public bool Attended { get; set; }

    }
}
