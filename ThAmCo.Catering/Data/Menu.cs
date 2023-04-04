using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        public Menu()
        {

        }


        public Menu(int menuId,
            string menuName) 
        {
            MenuId = menuId;

            MenuName = menuName;
        }

        public int MenuId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MenuName { get; set; } = null!;

        public ICollection<MenuFoodItem> FoodItems { get; set;}

        public ICollection<FoodBooking> FoodBookings { get; set; }
    }
}

