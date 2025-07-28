using MediatR;
using StudentManager.Application.Features.Users.DTOs;
using StudentManager.Domain.Entities;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Users.Queries
{
    public class GetPermissionByUserQuery : IRequest<ApiResponse<UserPermissionDTO>>
    {
        public Guid UserID { get; set; }
    }
}
