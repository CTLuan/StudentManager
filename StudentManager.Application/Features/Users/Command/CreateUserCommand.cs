using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Features.Users.Command;

namespace StudentManager.Application.Features.Users.Command
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
