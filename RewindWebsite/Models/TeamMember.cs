using System.ComponentModel.DataAnnotations;

namespace RewindWebsite.Models
{
    public class TeamMember
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string bio { get; set; }
        public string imageUrl { get; set; }
        public int experienceYears { get; set; }
    }
}
