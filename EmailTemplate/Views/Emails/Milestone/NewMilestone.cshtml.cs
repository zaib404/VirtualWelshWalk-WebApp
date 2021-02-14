using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailTemplate.Views.Emails.Milestone
{
    public class NewMilestoneModel : PageModel
    {
        public string MilestoneName { get; set; }

        public string Name { get; set; }

        public NewMilestoneModel(string milestoneName, string name)
        {
            MilestoneName = milestoneName;
            Name = name;
        }
    }
}
