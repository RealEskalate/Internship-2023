using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Tags.DTOs;
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
            #region _index Mappings

            CreateMap<_Index, _IndexDto>().ReverseMap();
            CreateMap<_Index, Create_IndexDto>().ReverseMap();

            CreateMap<Blog, BlogDto>()
            .ForMember(x => x.Rates, o => o.MapFrom(s => s.Rates))
            .ForMember(x => x.BlogRate, o => o.MapFrom(s => s.Rates.Any() ? s.Rates.Average(r => r.RateNo) : 0));

            CreateMap<Blog, CreateBlogDto>().ReverseMap();

            CreateMap<Blog, UpdateBlogDto>().ReverseMap();




            #endregion _index

            #region rate Mappings
            CreateMap<Rate, RateDto>().ReverseMap();
            CreateMap<Rate, UpdateRateDto>().ReverseMap();
            CreateMap<Rate, CreateRateDto>().ReverseMap();
            #endregion rate

            #region tag Mappings

            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();

            CreateMap<Tag, _IndexDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();

            #endregion Tag
            #region review Mappings
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            #endregion review
        }
    }
}
