using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region Index Mapping
            CreateMap<_Index, _IndexDto>().ReverseMap();
            CreateMap<_Index, Create_IndexDto>().ReverseMap();
            #endregion

            #region Authentication Mappings
            CreateMap<SignupFormDto, User>().ReverseMap();
            CreateMap<User, SignUpResponse>().ReverseMap();
            #endregion Authentication Mappings
        }
    }
}
