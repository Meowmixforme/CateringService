using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class PostMenuDTO
    {
        [Required]
        [StringLength(100)] // Example limit
        public string MenuName { get; set; } = null!;
    }
}
