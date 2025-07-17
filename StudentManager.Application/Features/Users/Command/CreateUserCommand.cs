using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Features.Users.Command;
using StudentManager.Shared.Contants;

namespace StudentManager.Application.Features.Users.Command
{
    public class CreateUserCommand : IRequest<ApiResponse<UserDto>>
    {
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
