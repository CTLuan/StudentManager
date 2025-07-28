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

namespace StudentManager.Tests.Unit.User
{
    public class CreateUserCommandHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRoleRepository> _roleRepositoryMock;
        private readonly Mock<IUserRoleRepository> _userRoleRepositoryMock;
        private readonly Mock<IPassword> _passwordMock;
        private readonly IMapper _mapperMock;
        private readonly CreateUserCommandHandler _handler;
        public CreateUserCommandHandlerTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _userRoleRepositoryMock = new Mock<IUserRoleRepository>();
            _passwordMock = new Mock<IPassword>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapperMock = config.CreateMapper();

            _handler = new CreateUserCommandHandler(_userRepositoryMock.Object, 
                                                    _mapperMock, 
                                                    _unitOfWorkMock.Object, 
                                                    _roleRepositoryMock.Object, 
                                                    _userRoleRepositoryMock.Object, 
                                                    _passwordMock.Object);
        }

        [Fact]
        public async Task Handle_Should_CreateUser_And_Commit()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                UserName = "testuser",
                EmailAddress = "test@gmail.com",
                Password = "$2a$12$fMOWcOJCvLJwyXiV7Bnd1uR8eWB3vaXyKFnj8p6QUOAl3agAcsHle"
            };

            //Act
            var result = await _handler.Handle(command, default);

            // Assert
            _userRepositoryMock.Verify(x => x.CreateUser(It.IsAny<StudentManager.Domain.Entities.User>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);

            Assert.NotNull(result);
        }
    }
}
