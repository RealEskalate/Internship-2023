using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain;
public class Book : BaseDomainEntity
{
    public string ApplicationUserId { get; set; }
    public int MovieId { get; set; }
    public int CinemaEntityId { get; set; }
    public int SeatId { get; set; }
    public CinemaEntity CinemaEntity { get; set; }
    public Movie Movie { get; set; }
    public Seat Seat { get; set; }
}
