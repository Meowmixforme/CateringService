using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class ReservationUpdateDTO
    {
        [Required, MinLength(13), MaxLength(13)]
        public string Reference { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        [Required]
        public string StaffId { get; set; }
    }
}