using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;

namespace StudentManager.Application.Features.Users.Command
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandle(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<StudentManager.Domain.Entities.User>(request);
            await _userRepository.CreateUser(userRequest);
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<UserDto>(userRequest);

            return response;
        }
    }
}
