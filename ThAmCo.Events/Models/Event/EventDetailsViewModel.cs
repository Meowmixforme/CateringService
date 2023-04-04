using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Models.GuestBooking;

namespace ThAmCo.Events.Models.Event
{
    public class EventDetailsViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh}h {0:mm}m {0:ss}s")]
        public TimeSpan? Duration { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm tt")]
        public DateTime Date { get; set; }

        public string EventTypeId { get; set; }

       public List<GuestBookingDetailsViewModel> Bookings { get; set; }

        public EventAlerts Alerts { get; set; }

       
    }
}
