using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Interfaces;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Auth.Query
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ApiResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPassword _password;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginQueryHandler(IUserRepository userRepository, IPassword password, IUserRoleRepository userRoleRepository,
                                 IRoleRepository roleRepository, IJwtService jwtService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _password = password;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ApiResponse<UserDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // Lấy người dùng từ repository
            var user = await _userRepository.GetUserByEmailAddress(request.EmailAddress);
            if (user == null)
                return ApiResponse<UserDto>.ErrorResponse("EmailAddress or Password is incorrect", 404);

            var comparePassword = await _password.VerifyPassword(request.Password, user.Password);
            if (!comparePassword)
                return ApiResponse<UserDto>.ErrorResponse("EmailAddress or Password is incorrect", 404);

            //var userRoles 
            var userRoles = await _roleRepository.GetRoleById(user.UserID);

            var accessToken = _jwtService.GenerateAccessToken(user, userRoles);
            var refreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _userRepository.UpdateUser(user);
            await _unitOfWork.SaveChangesAsync();

            var response = new UserDto()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                EmailAddress = request.EmailAddress,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return ApiResponse<UserDto>.SuccessResponse(response, "Login Success", 200);
        }
    }
}
