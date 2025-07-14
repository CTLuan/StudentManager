using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Domain.Interfaces;

namespace StudentManager.Application.Features.User.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByID(Guid.NewGuid());

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserID} not found.");
            }
            var response = _mapper.Map<UserDto>(user);
            //var response = new UserDto()
            //{
            //    UserID = user.UserID,
            //    UserName = user.UserName,
            //    EmailAddress = user.EmailAddress
            //};
            return response;
        }
    }
}
