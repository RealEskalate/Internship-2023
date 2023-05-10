using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Domain.Common;

namespace BlogApp.Domain
{
    public class Review: BaseDomainEntity
    {
        public int ReviewerId { get; set; }
        public string Comment { get; set; } = "";
        public int BlogId { get; set; }
        public bool? IsResolved { get; set; } = false;
    }
}