using System.ComponentModel.DataAnnotations;

namespace VirtualWelshWalk.DataAccess.Models
{
    public class VirtualWalk
    {
        [Key]
        public int VirtualWalkId { get; set; }

        [Required]
        [MaxLength(100)]
        public string VirtualWalkName { get; set; }

        public int TotalSteps { get; set; }

        public int PeopleId { get; set; }

        //public People People { get; set; }
    }
}