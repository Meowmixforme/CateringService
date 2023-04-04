namespace ThAmCo.Events.Models.Event
{
    // An enum to alert when any of the following alert conditions apply.
    public enum EventAlerts
    {
        //fewer than 1 member of staff to every 10 guests
        LessStaffThanRequired = 1 << 1,
        
        NoFirstAiderAssigned = 1,

        NoAlert = 0

    }
}
