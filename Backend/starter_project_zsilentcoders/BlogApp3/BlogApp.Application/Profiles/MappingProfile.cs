using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Blog.DTOs;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, _UserDto>().ReverseMap();
            CreateMap<User, Create_UserDto>().ReverseMap();
        }
    }
}
