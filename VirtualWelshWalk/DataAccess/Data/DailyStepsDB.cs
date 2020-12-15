using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWelshWalk.DataAccess.Data
{
    public class DailyStepsDB
    {
        [Required]
        [Range(1, 100000, ErrorMessage = "Can only input between 1-100000.")]   
        public int NewSteps { get; set; }

        public int TotalSteps { get; set; }

    }
}
