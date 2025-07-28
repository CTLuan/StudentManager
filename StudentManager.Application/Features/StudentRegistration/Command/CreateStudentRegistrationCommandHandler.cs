using AutoMapper;
using MediatR;
using StudentManager.Application.Features.Student.DTOs;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Domain.Entities;
using StudentManager.Shared.Exceptions;

namespace StudentManager.Application.Features.StudentRegistration.Command
{

    public class CreateStudentRegistrationCommandHandler : IRequestHandler<CreateStudentRegistrationCommand, ApiResponse<StudentRegistrationDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStudentRegistrationCommandHandler(IUserRepository userRepository,
                                                IMapper mapper,
                                                IStudentRegistrationRepository studentRegistrationRepository,
                                                IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _studentRegistrationRepository = studentRegistrationRepository;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ApiResponse<StudentRegistrationDto>> Handle(CreateStudentRegistrationCommand request, CancellationToken cancellationToken)
        {
            var studentRegistration = _mapper.Map<StudentManager.Domain.Entities.StudentRegistration>(request);

            studentRegistration.StudentCode = await _studentRegistrationRepository.GenerateUniqueStudentCodeAsync();

            var createStudentRegistration = await _studentRegistrationRepository.CreateStudentRegistration(studentRegistration);
            if(!createStudentRegistration)
                return ApiResponse<StudentRegistrationDto>.ErrorResponse("Failed to create student registration.", 500);

            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<StudentRegistrationDto>(studentRegistration);
            return ApiResponse<StudentRegistrationDto>.SuccessResponse(response, "Student registration created successfully.");
        }
    }
}
