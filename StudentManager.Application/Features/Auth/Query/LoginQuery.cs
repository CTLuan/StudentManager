using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Auth.Query
{
    public class LoginQuery : IRequest<ApiResponse<UserDto>>
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
