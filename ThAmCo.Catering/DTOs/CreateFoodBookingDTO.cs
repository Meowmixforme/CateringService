using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.DTOs
{
    public class CreateFoodBookingDTO
    {
        public int ClientReferenceId { get; set; }
        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; }
    }
}
