using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Models.Identity
{
    public class RegisterModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(10)]
        public string Password { get; set; }

        public string FullName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
