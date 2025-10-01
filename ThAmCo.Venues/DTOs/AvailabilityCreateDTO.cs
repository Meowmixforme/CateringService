using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class AvailabilityCreateDTO
    {
        [Required]
        public DateTime Date { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        [Range(0.0, double.MaxValue)]
        public double CostPerHour { get; set; }
    }
}
