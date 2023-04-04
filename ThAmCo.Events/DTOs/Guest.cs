using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.DTOs
{

    public class GuestDTO
    {

        public GuestDTO()
        {
        }

        public GuestDTO(int id, string forename, string surname, int payment, string emailAddress, bool deleted)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Payment = payment;
            EmailAddress = emailAddress;
            Deleted = deleted;

        }

        public int Id { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        // Method to combine fore + surnames
        public string DisplayName => Forename + " " + Surname;

        [Required]
        [MaxLength(8)]
        public int Payment { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public bool Deleted { get; set; }

        public ICollection<GuestBooking> Bookings { get; set; }



    }
}
