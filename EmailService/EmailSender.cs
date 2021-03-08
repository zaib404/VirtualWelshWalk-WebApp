using HtmlAgilityPack;
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

        public async Task SendPostcardEmailAsync(Message message)
        {
            var emailMessage = CreatePostcardEmailMessage(message);

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

            var bodyBuilder = new BodyBuilder();
            

            // Source - https://stackoverflow.com/questions/63712017/mailkit-email-doesnt-show-inline-images-on-gmail?noredirect=1&lq=1
            var doc = new HtmlDocument();
            doc.LoadHtml(message.Content);

            var nodes = doc.DocumentNode.SelectNodes("//img");

            if (nodes != null)
            {
                var imagePath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\WebPage\dbl_logo_with_text.png"}";

                var imgLogo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), imagePath);

                var SignatureWPath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\tim_educ8_signature.png"}";

                var imgSignatureW = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SignatureWPath);

                var SignatureEPath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\educ8_team_signature.png"}";

                var imgSignatureE = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SignatureEPath);

                foreach (var node in nodes)
                {
                    string file = "";

                    if (node.Id.ToLower() == "logo".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgLogo, node.GetAttributeValue("src", ""));
                    }
                    else if (node.Id.ToLower() == "SignatureW".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgSignatureW, node.GetAttributeValue("src", ""));
                    }
                    else if (node.Id.ToLower() == "SignatureE".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgSignatureE, node.GetAttributeValue("src", ""));
                    }

                    if (!File.Exists(file))
                    {
                        continue;
                    }

                    // Set content type to the current image's extension, such as "png" or "jpg"
                    var contentType = new ContentType("image", Path.GetExtension(file));
                    var contentId = MimeUtils.GenerateMessageId();
                    var image = (MimePart)bodyBuilder.LinkedResources.Add(file, contentType);
                    image.ContentTransferEncoding = ContentEncoding.Base64;
                    image.ContentId = contentId;

                    // Set the current image's src attriubte to "cid:<content-id>"
                    node.SetAttributeValue("src", $"cid:" + contentId);
                }
                bodyBuilder.HtmlBody = doc.DocumentNode.OuterHtml;
            }
            else
            {
                bodyBuilder.HtmlBody = message.Content;
            }

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

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private MimeMessage CreatePostcardEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            var bodyBuilder = new BodyBuilder();

            // Source - https://stackoverflow.com/questions/63712017/mailkit-email-doesnt-show-inline-images-on-gmail?noredirect=1&lq=1
            var doc = new HtmlDocument();
            doc.LoadHtml(message.Content);

            var nodes = doc.DocumentNode.SelectNodes("//img");

            if (nodes != null)
            {
                var logoPath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\WebPage\dbl_logo_with_text.png"}";

                var imgLogo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), logoPath);

                var imagePath = $"{Directory.GetCurrentDirectory()}{string.Format(@"\wwwroot{0}", message.PostCardImages)}";

                var imgCulture = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), imagePath);

                var SignatureWPath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\tim_educ8_signature.png"}";

                var imgSignatureW = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SignatureWPath);

                var SignatureEPath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Assets\educ8_team_signature.png"}";

                var imgSignatureE = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), SignatureEPath);

                foreach (var node in nodes)
                {
                    string file;

                    if (node.Id.ToLower() == "logo".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgLogo, node.GetAttributeValue("src", ""));
                    }
                    else if (node.Id.ToLower() == "SignatureW".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgSignatureW, node.GetAttributeValue("src", ""));
                    }
                    else if (node.Id.ToLower() == "SignatureE".ToLower())
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgSignatureE, node.GetAttributeValue("src", ""));
                    }
                    else
                    {
                        // File path to the image. We get the src attribute off the current node for the file name.
                        file = Path.Combine(imgCulture, node.GetAttributeValue("src", ""));
                    }
                    
                    if (!File.Exists(file))
                    {
                        continue;
                    }

                    // Set content type to the current image's extension, such as "png" or "jpg"
                    var contentType = new ContentType("image", Path.GetExtension(file));
                    var contentId = MimeUtils.GenerateMessageId();
                    var image = (MimePart)bodyBuilder.LinkedResources.Add(file, contentType);
                    image.ContentTransferEncoding = ContentEncoding.Base64;
                    image.ContentId = contentId;

                    // Set the current image's src attriubte to "cid:<content-id>"
                    node.SetAttributeValue("src", $"cid:" + contentId);
                }
                bodyBuilder.HtmlBody = doc.DocumentNode.OuterHtml;
            }
            else
            {
                bodyBuilder.HtmlBody = message.Content;
            }

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
