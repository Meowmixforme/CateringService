using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class ReservationPostDTO
    {
        [Required]
        public DateTime EventDate { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        [Required]
        public string StaffId { get; set; }
    }
}