using MediatR;
using StudentManager.Application.Features.Student.DTOs;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.StudentRegistration.Command
{
    public class CreateStudentRegistrationCommand : IRequest<ApiResponse<StudentRegistrationDto>>
    {
        public string? StudentName { get; set; }
        public string? ParentName { get; set; }
        public string? ParentPhone { get; set; }
        public string? ParentEmail { get; set; }
    }
}
