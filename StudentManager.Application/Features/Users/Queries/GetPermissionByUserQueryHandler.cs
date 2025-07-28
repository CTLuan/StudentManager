using MediatR;
using StudentManager.Application.Features.Users.DTOs;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Implementation;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Users.Queries
{
    public class GetPermissionByUserQueryHandler : IRequestHandler<GetPermissionByUserQuery, ApiResponse<UserPermissionDTO>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IActionRepository _actionRepository;

        public GetPermissionByUserQueryHandler( IDepartmentRepository departmentRepository, 
                                                IUserRepository userRepository, 
                                                IRoleRepository roleRepository,
                                                IActionRepository actionRepository)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _actionRepository = actionRepository ?? throw new ArgumentNullException(nameof(actionRepository));
        }

        public async Task<ApiResponse<UserPermissionDTO>> Handle(GetPermissionByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByID(request.UserID);
            var department = await _departmentRepository.GetDepartmentByUserID(request.UserID);
            var roles = await _roleRepository.GetRoleById(request.UserID);
            var actions = await _actionRepository.GetActionsByUserID(request.UserID);

            if (department == null || !department.Any())
                return ApiResponse<UserPermissionDTO>.ErrorResponse("No departments found for the user", 404);

            var response = new UserPermissionDTO()
            {
                UserID = request.UserID,
                UserDepartment = department,
                Roles = roles,
                Action = actions
            };

            return ApiResponse<UserPermissionDTO>.SuccessResponse(response, "Departments retrieved successfully", 200);
        }
    }
}
