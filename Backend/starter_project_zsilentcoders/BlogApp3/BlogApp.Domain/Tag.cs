using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Domain.Common;


namespace BlogApp.Domain
{
    public class Tag : BaseDomainEntity
    {
        
        public string Title {get; set;}
        public string Description {get; set;}

    }
}
