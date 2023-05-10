using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Profiles;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using BlogApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace BlogApp.Application.UnitTest.Blogs.Commands
{
//     public class CreateBlogCommandHandlerTest
//     {

//         private readonly IMapper _mapper;
//         private readonly Mock<IUnitOfWork> _mockRepo;
//         private readonly CreateBlogDto _blogDto;
//         private readonly CreateBlogCommandHandler _handler;
//         public CreateBlogCommandHandlerTest()
//         {
//             _mockRepo = MockUnitOfWork.GetUnitOfWork();
//             var mapperConfig = new MapperConfiguration(c =>
//             {
//                 c.AddProfile<MappingProfile>();
//             });
//             _mapper = mapperConfig.CreateMapper();

//             _blogDto = new CreateBlogDto
//             {
//                 Title = "blog title 3",
//                 Content = "Blog Content 3",
//                 CoverImage = "blog image 3",
//                 PublicationStatus= true
//         };

//             _handler = new CreateBlogCommandHandler(_mockRepo.Object, _mapper);

//         }


//         [Fact]
//         public async Task CreateBlog()
//         {
//             var result = await _handler.Handle(new CreateBlogCommand() { BlogDto = _blogDto }, CancellationToken.None);
//             result.ShouldBeOfType<Result<int>>();
//             Console.WriteLine("result: ", result);
//             result.Success.ShouldBeTrue();

//             var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
//             Blogs.Count.ShouldBe(3);

//         }

//         [Fact]
//         public async Task InvalidBlog_Added()
//         {

//             _blogDto.PublicationStatus = null;
//             var result = await _handler.Handle(new CreateBlogCommand() { BlogDto = _blogDto }, CancellationToken.None);
//             result.ShouldBeOfType<Result<int>>();
//             result.Success.ShouldBeFalse();
//             result.Errors.ShouldNotBeEmpty();
//             var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
//             Blogs.Count.ShouldBe(2);

//         }
//     }
// }


public class CreateBlogCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> unitOfWorkMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly Mock<IPhotoAccessor> photoAccessorMock;
    private readonly CreateBlogCommandHandler handler;

    public CreateBlogCommandHandlerTests()
    {
        unitOfWorkMock = MockUnitOfWork.GetUnitOfWork();
        mapperMock = new Mock<IMapper>();
        photoAccessorMock = new Mock<IPhotoAccessor>();
        handler = new CreateBlogCommandHandler(unitOfWorkMock.Object, mapperMock.Object, photoAccessorMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsSuccessResultWithBlogId()
    {
        // Arrange
        var blogDto = new CreateBlogDto { Title = "Test Blog", Content = "Test Content", PublicationStatus=true };
        var command = new CreateBlogCommand{BlogDto = blogDto};

        var photoUploadResult = new Result<Photo> { Success = true, Value = new Photo{Id = "1", Url= "test_image.jpg"} };
        photoAccessorMock.Setup(x => x.AddPhoto(It.IsAny<IFormFile>())).ReturnsAsync(photoUploadResult);

        mapperMock.Setup(x => x.Map<Blog>(blogDto)).Returns(new Blog { Id = 1 });

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Success.ShouldBeTrue();
        result.Value.ShouldBe(3);
        unitOfWorkMock.Verify(x => x.Save(), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ReturnsFailureResultWithValidationErrors()
    {
        // Arrange
        var blogDto = new CreateBlogDto(); // Invalid DTO
        var command = new CreateBlogCommand{BlogDto = blogDto};

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Success.ShouldBeFalse();
        result.Value.ShouldBe(0);
        result.Message.ShouldBe("Creation Failed");
        result.Errors.ShouldContain(x => x.Contains("Title") && x.Contains("required"));
        result.Errors.ShouldContain(x => x.Contains("Content") && x.Contains("required"));
        unitOfWorkMock.Verify(x => x.Save(), Times.Never);
    }

    [Fact]
    public async Task Handle_AddPhotoFails_ReturnsFailureResult()
    {
        // Arrange
        var file = new Mock<IFormFile>();
        file.Setup(f => f.Length).Returns(1024 * 1024); // 1 MB
        var fileData = Encoding.UTF8.GetBytes("invalid file");
        var stream = new MemoryStream(fileData);
        file.Setup(f => f.OpenReadStream()).Returns(stream);
        file.Setup(f => f.FileName).Returns("invalid.jpg");
        file.Setup(f => f.ContentType).Returns("image/jpeg");

        var blogDto = new CreateBlogDto
        {
            Title = "Test Blog",
            Content = "This is a test blog",
            PublicationStatus = true,
            File = file.Object
        };

        photoAccessorMock.Setup(pa => pa.AddPhoto(file.Object)).ReturnsAsync(new Result<Photo>
        {
            Success = false,
            Message = "Photo upload failed"
        });

        var command = new CreateBlogCommand{BlogDto = blogDto};

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Success.ShouldBeFalse();
        result.Message.ShouldBe("Photo upload failed");
        result.Value.ShouldBe(0);
    }
}


}