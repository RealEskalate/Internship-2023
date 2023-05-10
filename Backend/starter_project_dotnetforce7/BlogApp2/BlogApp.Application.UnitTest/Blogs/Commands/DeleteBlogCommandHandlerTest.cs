using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Blogs.CQRS.Handlers;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Responses;
using BlogApp.Application.UnitTest.Mocks;
using Moq;
using Shouldly;


namespace BlogApp.Application.UnitTest.Blogs.Commands
{
    public class DeleteBlogCommandHandlerTest
    {

        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteBlogCommandHandler _handler;

        private readonly Mock<IPhotoAccessor> _photoAccessorMock;

        public DeleteBlogCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

         _photoAccessorMock = new Mock<IPhotoAccessor>();
          
            _id = 1;

            _handler = new DeleteBlogCommandHandler(_mockRepo.Object, _photoAccessorMock.Object);

        }


        [Fact]
        public async Task DeleteBlog()
        {
            /* var create_result = await _handler.Handle(new CreateRateCommand(){ RateDto = _rateDto  }, CancellationToken.None);*/

            var result = await _handler.Handle(new DeleteBlogCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Blog_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeleteBlogCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            var Blogs = await _mockRepo.Object.BlogRepository.GetAll();
            Blogs.Count.ShouldBe(2);

        }
    }
}



