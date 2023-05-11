using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.DTO
{
    public class ConfirmEmailDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
    
}
