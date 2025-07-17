using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Interfaces;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Auth.Query
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, ApiResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RefreshTokenQueryHandler(IUserRepository userRepository, IJwtService jwtService, 
                                        IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UserDto>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAddress(request.EmailAddress);

            if (user == null)
                return ApiResponse<UserDto>.ErrorResponse("User not found", 404);

            if (user.RefreshToken != request.RefreshToken)
                return ApiResponse<UserDto>.ErrorResponse("RefreshToken is incorrect", 404);

            var userRole = await _roleRepository.GetRoleById(user.UserID);

            var accessToken = _jwtService.GenerateAccessToken(user, userRole);
            var refreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _userRepository.UpdateUser(user);

            await _unitOfWork.SaveChangesAsync();

            var response = new UserDto()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                EmailAddress = user.EmailAddress,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return ApiResponse<UserDto>.SuccessResponse(response, "Token refreshed successfully", 200);
        }
    }
}
