using System.ComponentModel.DataAnnotations;


namespace ThAmCo.Events.Models.Event
{
    public class EventCreateViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime Date { get; set;}

        public string  EventTypeId { get; set;}

        public ICollection<EventTypeViewModel> AllowedTypeId { get; set; }
    }
}
