using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.DTO;
public class CreateBookDto
{
    public int MovieId { get; set; }
    public int CinemaEntityId { get; set; }
    public int SeatId { get; set; }
}
