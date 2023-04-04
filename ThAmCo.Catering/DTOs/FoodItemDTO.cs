using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class FoodItemDTO
    {
        public int FoodItemId { get; set; }

        public string Description { get; set; } = null!;

        public float UnitPrice { get; set; }




    }
}
