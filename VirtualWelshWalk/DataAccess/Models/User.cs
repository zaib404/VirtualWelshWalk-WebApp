using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Models
{
    /// <summary>
    /// This class is adding on to IdentityUser class creating extra property fields
    /// and overriding some properties to give it dataannotations.
    /// </summary>
    public class User : IdentityUser
    {
        [ProtectedPersonalData]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [ProtectedPersonalData]
        [Required]
        [MaxLength(50)]
        public override string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public override string NormalizedUserName { get; set; }

        [Required]
        [MaxLength(100)]
        public override string NormalizedEmail { get; set; }


        [ProtectedPersonalData]
        [Required]
        [MaxLength(100)]
        public override string Email { get; set; }

        [PersonalData]
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastLoginDate { get; set; }
    }
}
