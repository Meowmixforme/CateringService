using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {

        public FoodItem()
        {

        }
        public FoodItem(int foodItemId,
            string description,
            float unitPrice)
        {
            FoodItemId = foodItemId;
            Description = description;
            UnitPrice = unitPrice;
        }

        public int FoodItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = null!;

        public float UnitPrice { get; set; }

        public ICollection<MenuFoodItem> Menus { get; set; }

    }
}
