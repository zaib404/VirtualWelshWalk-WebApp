using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailTemplate.Views.Emails.ChangeEmail
{
    public class ChangeEmailModel : PageModel
    {
        public string ConfirmEmailUrl { get; set; }

        public string Name { get; set; }

        public ChangeEmailModel(string confirmEmailUrl, string pName)
        {
            ConfirmEmailUrl = confirmEmailUrl;
            Name = pName;
        }
    }
}
