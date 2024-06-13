using AutoMapper;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Movie Mappings

            CreateMap<TaskCheckListEntity, TaskCheckListDto>().ReverseMap();
            CreateMap<TaskCheckListEntity, CreateTaskCheckListDto>().ReverseMap();

            CreateMap<TaskCheckListEntity, UpdateTaskCheckListDto>().ReverseMap();

            #endregion Movie
            CreateMap<TaskEntity, CreateTaskDto>().ReverseMap();
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskDto>().ReverseMap();
        }
    }
}
