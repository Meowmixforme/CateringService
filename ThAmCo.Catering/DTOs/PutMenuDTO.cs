using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class PutMenuDTO
    {
        public int MenuId { get; set; }

        [Required]
        [StringLength(100)] // Example max length
        public string MenuName { get; set; } = null!;
    }
}