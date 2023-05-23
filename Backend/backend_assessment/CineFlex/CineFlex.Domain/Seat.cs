using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain;
public class Seat : BaseDomainEntity
{
    public int HorizontalDistanceFromScreenCenter { get; set; }
    public int VerticalDistanceFromScreenCenter { get; set; }
    public int CinemaEntityId { get; set; }
    public CinemaEntity CinemaEntity { get; set; }
    public Nullable<int> BookId { get; set; }
    public Book? Book { get; set; }
}
