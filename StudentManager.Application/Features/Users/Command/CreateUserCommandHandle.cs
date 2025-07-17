using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Interfaces;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;

namespace StudentManager.Application.Features.Users.Command
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, ApiResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPassword _password;

        public CreateUserCommandHandle(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, 
                                       IRoleRepository roleRepository, IUserRoleRepository userRoleRepository,
                                       IPassword password)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _password = password;
        }

        public async Task<ApiResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<StudentManager.Domain.Entities.User>(request);

            var user = await _userRepository.GetUserByEmailAddress(request.EmailAddress);

            if (user != null)
                return ApiResponse<UserDto>.ErrorResponse("Email Address already exists", 400);

            var paswordHash = await _password.HashPassword(request.Password);
            userRequest.Password = paswordHash;
            await _userRepository.CreateUser(userRequest);

            var roleGuest = await _roleRepository.GetRoleByName("Guest");
            var userRole = new UserRole()
            {
                UserID = userRequest.UserID,
                RoleID = roleGuest.RoleID
            };
            var createUserRole = await _userRoleRepository.CreateUserRole(userRole);

            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<UserDto>(userRequest);
            return ApiResponse<UserDto>.SuccessResponse(response, "Login Success!", 200);
        }
    }
}
