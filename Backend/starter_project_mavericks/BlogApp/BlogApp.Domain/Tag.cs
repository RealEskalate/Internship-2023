using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain
{
    public class Tag : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
