using CineFlex.Domain.Common;

namespace CineFlex.Domain
{
    public class Seat : BaseDomainEntity
    {


        
        public string SeatNumber { get; set; }

        public string SeatType { get; set; }

    
    

        public bool Available { get; set; }

        
        public decimal Price { get; set; }

        
    }
}