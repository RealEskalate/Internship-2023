using AutoMapper;
using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Domain.Models.Identity;
using System;
using Microsoft.AspNetCore.Http;
using BlogApp.Application.Constants;
using System.Security.Claims;
using BlogApp.Domain;
using BlogApp.Application.Models.Identity;

namespace BlogApp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IMapper _userMapper;
        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            });

            // Create the mapper
            _userMapper = config.CreateMapper();
        }

        public async Task<ApplicationUserDTO> GetCurrentUser()
        {

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("HttpContext is null");
            }
            var userId = httpContext.User.FindFirstValue(CustomClaimTypes.Uid);
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(userId);
            // Map ApplicationUser to ApplicationUserDto
            var userDto = _userMapper.Map<ApplicationUserDTO>(user);
            return userDto;
        }

        public async Task<ApplicationUserDTO> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
    
            if (user == null)
                return null;

            var userDto = _userMapper.Map<ApplicationUserDTO>(user);
            return userDto;
        }


        public async Task<List<ApplicationUserDTO>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            if (users == null)
                return new List<ApplicationUserDTO>();

            var userDtos = new List<ApplicationUserDTO>();
            foreach (var user in users)
            {
                var userDto = _userMapper.Map<ApplicationUserDTO>(user);
                userDtos.Add(userDto);
            }
            return userDtos;
        }
    }
}