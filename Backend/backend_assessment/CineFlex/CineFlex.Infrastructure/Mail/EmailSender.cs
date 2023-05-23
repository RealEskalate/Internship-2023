﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using CineFlex.Application.Constants.Infrustructure;
using CineFlex.Application.Models.Email;
using CineFlex.Application.Responses;

namespace CinFlex.Infrastructure.Mail
{
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
            catch (Exception ex)
            {
                //log an error message or throw an exception or both.
                throw new Exception("Samuel Abatneh" + $"{_emailSettings.UserName} Hello world" + ex.ToString() + $"{email}");
                result.Success = false;
                result.Errors.Add(ex.Message);

            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }


            if (result.Success)
                result.Value = email;

            return result;
        }
    }
}
