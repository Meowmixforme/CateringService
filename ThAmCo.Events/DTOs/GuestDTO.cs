namespace ThAmCo.Events.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DisplayName => Forename + " " + Surname;
        public int Payment { get; set; }
        public string EmailAddress { get; set; }
        public bool Deleted { get; set; }
    }
}