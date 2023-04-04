using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Staff
    {
        public Staff() 
        {
        }

        public Staff(int id, string name, string email, string role, bool firstAidQulaified) 
        
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            FirstAidQulaified = firstAidQulaified;
            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

        //If member of staff is first aid qualified
        public bool FirstAidQulaified { get; set; }

        public List<Staffing> Events { get; set; }
    }
}
