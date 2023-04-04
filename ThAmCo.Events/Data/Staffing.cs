using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    public class Staffing
    {
        [Key,Column(Order = 0)]
        public int StaffId { get; set; }

        public Staff Staff { get; set; }

        [Key,Column(Order = 1)]
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}
