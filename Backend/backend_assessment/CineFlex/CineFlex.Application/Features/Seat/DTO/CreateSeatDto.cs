using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTO;
public class CreateSeatDto
{
    public int HorizontalDistanceFromScreenCenter { get; set; }
    public int VerticalDistanceFromScreenCenter { get; set; }
    public int CinemaEntityId { get; set; }
}
