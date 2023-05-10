using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Features.Ratings.DTOs;
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

            CreateMap<_Index, _IndexDto>().ReverseMap();
            CreateMap<_Index, Create_IndexDto>().ReverseMap();
            CreateMap<Comment,CreateCommentDto>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Comment,UpdateCommentDto>().ReverseMap();

            #endregion _index
            #region Authentication Mappings
            CreateMap<SignupFormDto, User>().ReverseMap();
            CreateMap<User, SignUpResponse>().ReverseMap();
            #endregion Authentication Mappings

            CreateMap<Rating, RatingDto>().ReverseMap();
        }
    }
}
