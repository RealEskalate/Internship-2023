﻿using BlogApp.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Tags.DTOs
{
    public class Update_TagDto :BaseDto, I_TagDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}