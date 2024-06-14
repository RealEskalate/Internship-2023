using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Post : BaseDomainEntity
    {
        public string Title {get;set;}
        public string Content {get;set;}
        public int UserId{get;set;}
        
    }
}