using System.Net;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlogApp.Infrastructure.Mail;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public async Task<bool> sendEmail(Email email)
    {
        var Client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress()
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var Message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await Client.SendEmailAsync(Message);
        return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;
    }
}
