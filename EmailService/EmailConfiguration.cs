using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
    /// <summary>
    /// This class contains properties needed to configure sending email messages from our application
    /// Use the appSettings.json file to fill these properties in.
    /// </summary>
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
