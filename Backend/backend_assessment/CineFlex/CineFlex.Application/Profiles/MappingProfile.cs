using AutoMapper;
using CineFlex.Application.Features.CheckList.DTOs;
using CineFlex.Application.Features.Task.DTO;
using CineFlex.Application.Features.Task.Dtos;
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
            #region 

            CreateMap<CheckList, CheckListDto>().ReverseMap();
            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();

            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();

            #endregion
            CreateMap<Domain.TaskEntity, CreateTaskDto>().ReverseMap();
            CreateMap<Domain.TaskEntity, TaskDto>().ReverseMap();
            CreateMap<Domain.TaskEntity, UpdateTaskDto>().ReverseMap();
        }
    }
}
