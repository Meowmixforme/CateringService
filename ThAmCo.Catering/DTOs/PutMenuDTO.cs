using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class PutMenuDTO
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; } = null!;

        
    }
}