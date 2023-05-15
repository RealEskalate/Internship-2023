using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain
{
    public class Comment : BaseDomainEntity
    {

        public string Commenter { get; set; }

        public string Content { get; set; }

        public string BlogId { get; set; }



    }
}
