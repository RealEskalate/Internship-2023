using BlogApp.Application.Models.Mail;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Contracts.Identity;

public interface IEmailSender
{
    Task<Result<Email>> sendEmail(Email email);
}
