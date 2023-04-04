using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class MenuFoodItemDTO
    {
        public int MenuId { get; set; }

        public MenuDTO Menu { get; set; }

        public int FoodItemId { get; set; }

        public FoodItemDTO FoodItem { get; set; }
    }
}
