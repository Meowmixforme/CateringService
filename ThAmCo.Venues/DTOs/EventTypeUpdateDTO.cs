using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.DTOs
{
    public class EventTypeUpdateDTO
    {
        [Required, MinLength(3), MaxLength(3)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
