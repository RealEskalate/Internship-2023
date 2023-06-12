﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.DTOs
{
    public class CreateTaskCheckListDto : ITaskCheckListDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }  
        public bool isComplete { get; set; }
    }
}
