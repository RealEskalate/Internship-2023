using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Domain;
using Moq;
using Newtonsoft.Json.Linq;

namespace BlogApp.UnitTests.Mocks;

public class MockAuthRepository
{
    private static ICollection<SignUpResponse> users;
    private static int id = 1;
    public static Mock<IAuthRepository> GetAuthRepository()
    {
       var mockRepo = new Mock<IAuthRepository>();

       mockRepo.Setup(u => u.SignUpAsync(It.IsAny<SignupFormDto>()))
       .Callback((SignupFormDto signupFormDto) => {
            var user = new SignUpResponse {
                Id = id.ToString(),
                FirstName = signupFormDto.FirstName,
                LastName = signupFormDto.LastName,
                Email = signupFormDto.Email
            };

            id += 1;
            
            users.Add(user);
            
            return user;
       });
           

       mockRepo.Setup(u=> u.SignInAsync(It.IsAny<SigninFormDto>()))
       .Callback((SigninFormDto signinFromDto) => {
            
       });

       return mockRepo;

    }
}