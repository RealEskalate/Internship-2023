﻿using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Features.Ratings.DTOs;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Reviews.DTOs;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region _index Mappings

            CreateMap<_Index, _IndexDto>().ReverseMap();
            CreateMap<_Index, Create_IndexDto>().ReverseMap();
            CreateMap<Comment,CreateCommentDto>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Comment,UpdateCommentDto>().ReverseMap();

            #endregion _index

            #region rating Mappings

            CreateMap<Rating, RatingDto>().ReverseMap();

            #endregion rating
            
            #region blog Mappings

            CreateMap<Blog, CreateBlogDTO>().ReverseMap();
            CreateMap<Blog, BlogDTO>().ReverseMap();
            CreateMap<Blog, BlogListDTO>().ReverseMap();
            CreateMap<Blog, UpdateBlogDTO>().ReverseMap();

            #endregion blog

            #region review Mappings

            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();

            #endregion
            #region tag Mapping

            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, updateTagDto>().ReverseMap();
            CreateMap<Tag, createTagDto>().ReverseMap();

            #endregion tag
        }
    }
}
