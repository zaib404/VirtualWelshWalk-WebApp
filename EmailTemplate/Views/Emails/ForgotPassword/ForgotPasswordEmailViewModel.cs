using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplate.Views.Emails.ForgotPassword
{
    public class ForgotPasswordEmailViewModel
    {
        public string ConfirmEmailUrl { get; set; }

        public string Name { get; set; }

        public ForgotPasswordEmailViewModel(string confirmEmailUrl, string pName)
        {
            ConfirmEmailUrl = confirmEmailUrl;
            Name = pName;
        }
    }
}
