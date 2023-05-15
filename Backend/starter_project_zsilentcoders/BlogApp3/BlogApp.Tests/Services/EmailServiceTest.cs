using System.Threading.Tasks;
using BlogApp.Application.Models.Mail;
using BlogApp.Tests.Mocks;
using Xunit;
using Shouldly;

namespace BlogApp.Tests.Services
{
    public class EmailServiceTest
    {
        [Fact]
        public async Task SendEmail_Success()
        {
            // Arrange
            var emailSender = MockEmail.CreateEmailSender();

            var email = new Email
            {
                To = "user0@gmail.com",
                Subject = "Test Email",
                Body = "This is a test email."
            };

            // Act
            var result = await emailSender.sendEmail(email);

            //Assert
            result.Success.ShouldBe(true);
        }

        [Fact]
        public async Task SendEmail_Failure()
        {
            // Arrange
            var emailSender = MockEmail.CreateEmailSender();

            var email = new Email
            {
                To = "invalid-email",
                Subject = "Test Email",
                Body = "This is a test email."
            };

            // Act
            var result = await emailSender.sendEmail(email);

            // Assert
            result.Success.ShouldBe(false);
            Assert.Single(result.Errors);
        }
    }
}
