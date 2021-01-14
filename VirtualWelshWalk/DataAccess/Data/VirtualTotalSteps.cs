using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class VirtualTotalSteps
    {
        [Required]
        [Display(Name = "Value")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater then or equal to 1.")]
        public int NewSteps { get; set; }

        public int TotalSteps { get; set; }
    }
}
