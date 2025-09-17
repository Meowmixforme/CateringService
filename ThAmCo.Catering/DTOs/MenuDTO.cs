using System.Collections.Generic;

namespace ThAmCo.Catering.DTOs
{
    public class MenuDTO
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = null!;
        public ICollection<FoodItemDTO> FoodItems { get; set; } = new List<FoodItemDTO>();
    }
}
