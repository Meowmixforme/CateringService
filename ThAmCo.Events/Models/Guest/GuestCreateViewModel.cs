using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Models.Guest
{
    public class GuestCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        [MaxLength(8)]
        public int Payment { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
