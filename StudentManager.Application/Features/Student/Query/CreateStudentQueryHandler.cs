using AutoMapper;
using MediatR;
using StudentManager.Application.Features.Student.DTOs;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Student.Query
{
    public class CreateStudentQueryHandler : IRequestHandler<CreateStudentQuery, ApiResponse<StudentDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;   

        public CreateStudentQueryHandler(IUserRepository userRepository,
                                         IStudentRegistrationRepository studentRegistrationRepository,
                                         IUnitOfWork unitOfWork,
                                         IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _studentRegistrationRepository = studentRegistrationRepository;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
         
        public async Task<ApiResponse<StudentDto>> Handle(CreateStudentQuery request, CancellationToken cancellationToken)
        {
            var studentRegistration = await _studentRegistrationRepository.GetStudentRegistrationById(request.StudentID);
            if (studentRegistration == null)
                return ApiResponse<StudentDto>.ErrorResponse("Student registration not found.", 404);

            var student = _mapper.Map<StudentManager.Domain.Entities.Student>(studentRegistration);
            var createStudent = await _studentRepository.CreateStudent(student);
            if (!createStudent)
                return ApiResponse<StudentDto>.ErrorResponse("Failed to create student.", 500);

            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<StudentDto>.SuccessResponse(_mapper.Map<StudentDto>(student), "Student created successfully.");
        }
    }
}
