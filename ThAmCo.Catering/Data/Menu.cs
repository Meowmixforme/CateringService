using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        public Menu()
        {
            FoodItems = new List<MenuFoodItem>();
            FoodBookings = new List<FoodBooking>();
        }

        public Menu(int menuId, string menuName)
        {
            MenuId = menuId;
            MenuName = menuName;
            FoodItems = new List<MenuFoodItem>();
            FoodBookings = new List<FoodBooking>();
        }

        public int MenuId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MenuName { get; set; } = null!;

        public ICollection<MenuFoodItem> FoodItems { get; set; } = new List<MenuFoodItem>();

        public ICollection<FoodBooking> FoodBookings { get; set; } = new List<FoodBooking>();
    }
}
