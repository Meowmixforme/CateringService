using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThAmCo.Events.FoodItems;

namespace ThAmCo.Events.FoodItemsa
{
    public class MenuFoodItem

    {

        public MenuFoodItem()
        {

        }

        public MenuFoodItem(int menuId,
            int foodItemId)
        {
            MenuId = menuId;
            FoodItemId = foodItemId;
        }
        //Column order for composite keys
        [Key, Column(Order = 0)]
        public int FoodItemId { get; set; }

        public FoodItem FoodItem { get; set; }
        //Column order for composite keys
        [Key, Column(Order = 1)]
        public int MenuId { get; set; }

        public Menu Menu { get; set; }


    }
}

