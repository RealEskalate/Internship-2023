using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class CinemaEntity:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }

        public int row { get; set; }
        public int col {get;set;}
    }
}
