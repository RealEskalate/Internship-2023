using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Models.Email
{

    public class Email
    {
        [EmailAddress]
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
