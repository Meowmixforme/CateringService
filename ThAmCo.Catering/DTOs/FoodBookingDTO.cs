using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class FoodBookingDTO
    {
        public int FoodBookingId { get; set; }

        public int ClientReferenceId { get; set; }

        public int NumberOfGuests { get; set; }

        public int MenuId { get; set; }

        public MenuDTO Menu { get; set; }
    }
}
