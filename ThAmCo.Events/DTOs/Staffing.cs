using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.DTOs
{
    public class StaffingDTO
    {
        [Key, Column(Order = 0)]
        public int StaffId { get; set; }

        public Staff Staff { get; set; }

        [Key, Column(Order = 1)]
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}
