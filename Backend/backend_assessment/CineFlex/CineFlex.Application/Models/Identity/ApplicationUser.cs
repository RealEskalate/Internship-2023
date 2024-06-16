using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Models.Identity
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
