using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public FoodItem() { }

        public FoodItem(int foodItemId, string description, float unitPrice)
        {
            FoodItemId = foodItemId;
            Description = description;
            UnitPrice = unitPrice;
            Menus = new List<MenuFoodItem>();
        }

        public int FoodItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = null!;

        public float UnitPrice { get; set; }

        public ICollection<MenuFoodItem> Menus { get; set; } = new List<MenuFoodItem>();
    }
}
