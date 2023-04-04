

namespace ThAmCo.Events.FoodItems
{
    public class FoodBooking
    {


        public FoodBooking()
        {

        }


        public FoodBooking(int foodBookingId,
            int clientReferenceId,
            int numberOfGuests,
            int menuId)
        {
            FoodBookingId = foodBookingId;
            ClientReferenceId = clientReferenceId;
            NumberOfGuests = numberOfGuests;
            MenuId = menuId;
        }

        public int FoodBookingId { get; set; }

        public int ClientReferenceId { get; set; }

        public int NumberOfGuests { get; set; }

        public int MenuId {get; set;}

      
    }
}

