

using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seat: BaseDomainEntity
    {
        public string Name { get; set; }
        public bool Available { get; set; }
        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }  
    }
}