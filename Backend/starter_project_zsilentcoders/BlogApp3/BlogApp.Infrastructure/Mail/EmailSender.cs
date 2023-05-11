using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Mail;
using BlogApp.Application.Responses;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BlogApp.Infrastructure.Mail;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    private MimeMessage CreateEmailMessage(Email email)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("email", _emailSettings.From));
        emailMessage.To.Add(new MailboxAddress("email", email.To));
        emailMessage.Subject = email.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = email.Body };
        return emailMessage;
    }

    public async Task<Result<Email>> sendEmail(Email email)
    {
        var result = new Result<Email>();
        result.Success = true;

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password);
            var sent = await client.SendAsync(CreateEmailMessage(email));
        }
        catch(Exception ex)
        {
            //log an error message or throw an exception or both.
            result.Success = false;
            result.Errors.Add(ex.Message);
            
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
        

        if(result.Success)
            result.Value = email;

        return result;
    }
}