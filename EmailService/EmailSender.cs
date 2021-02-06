using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        readonly EmailConfiguration emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsyn(emailMessage);
        }

        private async Task SendAsyn(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(emailConfiguration.UserName, emailConfiguration.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            var bodyBuilder = new BodyBuilder { TextBody = message.Content };

            var imagePath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\WebPage\logo_with_text.png"}";

            var image = bodyBuilder.LinkedResources.Add(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), imagePath));

            image.ContentId = MimeUtils.GenerateMessageId();
            
            bodyBuilder.HtmlBody = string.Format(message.Content, image.ContentId);

            if (message.Attachments != null)
            {
                List<string> attachmentPath = new List<string>();

                for (int i = 0; i < message.Attachments.Count; i++)
                {
                    attachmentPath.Add(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), message.Attachments[i]));
                }

                for (int i = 0; i < attachmentPath.Count; i++)
                {
                    bodyBuilder.Attachments.Add(attachmentPath[i]);
                }
            }

            //if (message.Attachments != null && message.Attachments.Any())
            //{
            //    byte[] fileBytes;
            //    foreach (var attachment in message.Attachments)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            attachment.CopyTo(ms);
            //            fileBytes = ms.ToArray();
            //        }

            //        bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            //    }
            //}

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailConfiguration.UserName, emailConfiguration.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
