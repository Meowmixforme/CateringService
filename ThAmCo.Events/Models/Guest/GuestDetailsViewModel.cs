using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ThAmCo.Events.Data;
using ThAmCo.Events.Models.GuestBooking;

namespace ThAmCo.Events.Models.Guest
{
    public class GuestDetailsViewModel
    {
        public int Id { get; set; }
        public string Forename { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Full Name")]
        public string DisplayName => Forename + " " + Surname;

        [Display(Name = "Credit Card Number")]
        public int Payment { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public List<GuestBookingDetailsViewModel> Bookings { get; set; }


    }
}
