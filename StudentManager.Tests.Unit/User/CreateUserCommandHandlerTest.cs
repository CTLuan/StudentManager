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

namespace StudentManager.Tests.Unit.User
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task Handle_Should_CreateUser_And_Commit()
        {
            //var mockUserRepository = new Mock<IUserRepository>();
            //var mockUnitOfWork = new Mock<IUnitOfWork>();

            ////var handler = new CreateUserCommandHandle(
            ////    mockUserRepository.Object,
            ////    null, // Assuming AutoMapper is not needed for this test
            ////    mockUnitOfWork.Object
            ////);

            //var command = new CreateUserCommand
            //{
            //    UserName = "TestUser",
            //    //Address = "Test Address",
            //    EmailAddress = "test@gmail.com"
            //};

            //// Act
            //var result = await handler.Handle(command, CancellationToken.None);


            //// Assert
            //mockUserRepository.Verify(r => r.CreateUser(It.Is<StudentManager.Domain.Entities.User>(o =>
            //    o.UserName == command.UserName && o.EmailAddress == command.EmailAddress)), Times.Once);

            //mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
            //Assert.NotNull(result);
        }
    }
}
