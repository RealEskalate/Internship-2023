using CineFlex.Application.Features.Common;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Genres.DTO
{
    public class UpdateGenreDto : BaseDto
    {
        public string Name { get; set; }
    }
}
