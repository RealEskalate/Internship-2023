using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain

{
    public enum UserRole
    {
    Admin,User
    }
    public class User : BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string AccountId { get; set; }
       
    }
}
