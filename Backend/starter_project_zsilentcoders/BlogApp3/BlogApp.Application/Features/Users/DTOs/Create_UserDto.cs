using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Application.Features._Indices.DTOs
{
    public class Create_UserDto : I_UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string AccountId { get; set; }

    }
}
