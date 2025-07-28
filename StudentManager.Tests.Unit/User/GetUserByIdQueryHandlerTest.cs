using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StudentManager.Domain.Interfaces;
using Moq;
using StudentManager.Application.Features.Users.Command;
using StudentManager.Domain.Entities;
using StudentManager.Application.Interfaces;
using AutoMapper;
using StudentManager.Infrastructure.Persistence.Implementation;
using StudentManager.Application.Mapping;
using StudentManager.Application.Features.User.Queries;

namespace StudentManager.Tests.Unit.User
{
    public class GetUserByIdQueryHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapperMock;
        private readonly GetUserByIdQueryHandler _handler;
        public GetUserByIdQueryHandlerTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapperMock = config.CreateMapper();

            _handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object, 
                                                    _mapperMock);
        }

        [Fact]
        public async Task Handle_Should_CreateUser_And_Commit()
        {
            // Arrange
            var userID = Guid.Parse("9E666A5D-8BA2-42E2-8DC4-FA560737C6A4");

            var user = new StudentManager.Domain.Entities.User()
            {
                UserID = userID,
                UserName = "testuser",
                EmailAddress = "test@gmail.com"
            };

            _userRepositoryMock.Setup(x =>x.GetUserByID(userID)).ReturnsAsync(user);

            var query = new GetUserByIdQuery
            {
                UserID = userID
            };

            //Act
            var result = await _handler.Handle(query, default);

            // Assert
            _userRepositoryMock.Verify(x => x.GetUserByID(query.UserID), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
        }
    }
}
