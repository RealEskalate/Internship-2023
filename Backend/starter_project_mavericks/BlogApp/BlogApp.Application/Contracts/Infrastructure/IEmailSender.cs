using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmail(string to, string subject, string html, string from = null);
    }
}
