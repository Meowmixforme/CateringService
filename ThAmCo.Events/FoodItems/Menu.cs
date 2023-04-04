using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.FoodItems
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



        public ICollection<FoodBooking> FoodBookings { get; set; }
    }
}

