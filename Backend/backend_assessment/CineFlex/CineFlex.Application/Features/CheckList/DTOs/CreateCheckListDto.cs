using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.DTOs
{
    public class CreateCheckListDto : ICheckListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskID { get; set; }
        public bool Status { get; set; }
    }
}
