using BlogApp.Application.Models.Mail;

namespace BlogApp.Application.Contracts.Identity;

public interface IEmailSender
{
    Task<bool> sendEmail(Email email);
}
