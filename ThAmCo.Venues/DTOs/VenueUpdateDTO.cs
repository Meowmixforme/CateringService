using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class VenueUpdateDTO
    {
        [Required, MaxLength(5)]
        public string Code { get; set; } // or just use route param for Code

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}