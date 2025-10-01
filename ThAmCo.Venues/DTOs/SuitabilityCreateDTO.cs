using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class SuitabilityCreateDTO
    {
        [Required, MinLength(3), MaxLength(3)]
        public string EventTypeId { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }
    }
}