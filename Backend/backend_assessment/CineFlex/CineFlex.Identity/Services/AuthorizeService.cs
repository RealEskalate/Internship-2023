// using Microsoft.AspNetCore.Identity;
// using CineFlex.Application.Contracts.Identity;
// using CineFlex.Application.Contracts.Persistence;
// using CineFlex.Domain;
// using CineFlex.Identity.Models;

// public class AuthorizationService : IAuthorizationService
// {

//     private readonly UserManager<CineFlexUser> _userManager;

//     public AuthorizationService(UserManager<CineFlexUser> userManager)
//     {
//         _userManager = userManager;

//     }

//     public async Task<bool> UserTaskBelongsToUser(UserTask userTask, string userId)
//     {
//         return userTask.UserId == userId;
//     }

//     public async Task<bool> ProductBelongsToUser(Product Product, string userId)
//     {
//         var expected = Product.UserTask.UserId;
//         return expected == userId;
//     }

//     public async Task<bool> IsAdmin(string userId)
//     {
//         var user = await _userManager.FindByIdAsync(userId);
//         return await _userManager.IsInRoleAsync(user, "Admin");
//     }

//     public async Task<bool> UserCanCreatTask(string CreatorId, string CreatedId)
//     {
//         return CreatedId == CreatorId;
//     }
// }
