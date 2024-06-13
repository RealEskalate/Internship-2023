using CineFlex.Application.Models.Email;
using CineFlex.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Constants.Infrustructure
{
    public interface IEmailSender
    {
        Task<Result<Email>> sendEmail(Email email);
    }
}
