using BlogApp.Application.Contracts.Infrastructure;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Models.Infrastructure;
using Microsoft.Extensions.Options;
using System.Net.Mail;


namespace BlogApp.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmail(string to, string subject, string html, string from = null)
        {
            // create message
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.EmailFrom);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = html;

            // send email
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(_emailSettings.EmailFrom, _emailSettings.SmtpPass);
            smtp.Host = _emailSettings.SmtpHost;
            smtp.Port = _emailSettings.SmtpPort;
            try
            {
                await smtp.SendMailAsync(mailMessage);
            }
            catch 
            {
                throw new NetworkException("Unable to send email. Please try again later.");
            }
        }
    }
}
