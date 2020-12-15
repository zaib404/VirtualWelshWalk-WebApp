using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Models
{
    /// <summary>
    /// This class is the db table to people
    /// Containing ID first name, last name and a foreign key
    /// </summary>
    public class People
    {
        [Key]
        public int PeopleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public List<VirtualWalk> VirtualWalk { get; set; }
    }
}
