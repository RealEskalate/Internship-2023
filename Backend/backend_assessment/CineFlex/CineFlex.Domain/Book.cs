using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain
{
    public class Book: BaseDomainEntity
    {
        public string Cinima { get; set; }
        public string Movie { get; set; }
        public string Seat { get; set; }
    }
}
