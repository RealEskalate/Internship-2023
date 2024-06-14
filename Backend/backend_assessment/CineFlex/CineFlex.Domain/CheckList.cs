using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class CheckList: BaseDomainEntity
    {
        
        public int TaskID { get; set; }
        public bool status { get; set; }

    }
}
