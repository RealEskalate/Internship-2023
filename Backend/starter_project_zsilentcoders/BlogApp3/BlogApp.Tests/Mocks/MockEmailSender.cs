using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Mail;
using BlogApp.Infrastructure.Mail;
using Microsoft.Extensions.Options;
using Moq;

namespace BlogApp.Tests.Mocks
{
    public static class MockEmail
    {
        public static IEmailSender CreateEmailSender()
        {
            var emailSettings = new EmailSettings
            {
                From = "yabitekuam@gmail.com",
                SmtpServer = "smtp.gmail.com",
                Port = 465,
                UserName = "yabitekuam@gmail.com",
                Password = "jnoyvqrialgetlxd"
            };

            var optionsMock = new Mock<IOptions<EmailSettings>>();
            optionsMock.Setup(x => x.Value).Returns(emailSettings);

            return new EmailSender(optionsMock.Object);
        }
    }
}
