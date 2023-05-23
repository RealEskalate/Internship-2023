using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Books.DTO;
public class UpdateBookDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int CinemaEntityId { get; set; }
    public List<int> SeatIds { get; set; }
}
