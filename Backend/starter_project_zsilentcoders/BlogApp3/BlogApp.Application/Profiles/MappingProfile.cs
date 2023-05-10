using AutoMapper;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Tags.DTOs;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Features.Blog.DTOs;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            #region _index Mappings

            CreateMap<_Index, _IndexDto>().ReverseMap();
            CreateMap<_Index, Create_IndexDto>().ReverseMap();

            #endregion _index

            #region Blog Mappings
            CreateMap<CreateBlogDto, Blog>()
                .ForMember(dest => dest.PublicationStatus,
                    opt => opt.MapFrom(src => src.Publish ? PublicationStatuses.Published : PublicationStatuses.NotPublished))
                .ForMember(dest => dest.DateCreated,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<BlogDetailsDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<BlogListDto, Blog>().ReverseMap();

            #endregion Blog




            #region tag Mappings
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<TagDetailsDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();
            CreateMap<TagListDto, Tag>().ReverseMap();

             #endregion tag
        }
    }
}
}