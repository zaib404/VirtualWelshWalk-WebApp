using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Models
{
    public class VirtualMilestone
    {
        [Key]
        public int VirtualMilestoneId { get; set; }

        [PersonalData]
        [Required]
        [MaxLength(100)]
        public string VirtualWalkName { get; set; }

        public int PeopleId { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)]
        public bool Milestone1 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)]
        public bool Milestone2 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)]
        public bool Milestone3 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)]
        public bool Milestone4 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone5 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone6 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone7 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone8 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone9 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone10 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone11 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone12 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone13 { get; set; }
        
        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone14 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone15 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone16 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone17 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone18 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone19 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone20 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone21 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone22 { get; set; }

        [PersonalData]
        [Column(TypeName = "bit")]
        [DefaultValue(false)] 
        public bool Milestone23 { get; set; }
    }
}
