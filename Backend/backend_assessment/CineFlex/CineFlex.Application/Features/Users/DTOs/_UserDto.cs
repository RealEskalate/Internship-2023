using CineFlex.Application.Features.Common;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CineFlex.Application.Features.Users.DTOs
{
    public class _UserDto : BaseDto, I_UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



    }
}
