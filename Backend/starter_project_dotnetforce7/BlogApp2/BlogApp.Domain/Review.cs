using BlogApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain
{
    public class Review : BaseDomainEntity
    {
        public int ReviewerId { get; set; }
        public string? ReviewContent { get; set; }
        public int BlogId { get; set; }
        public bool isResolved { get; set; }
    }
}