using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class VenueCreateDTO
    {
        [Required, MaxLength(5)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}