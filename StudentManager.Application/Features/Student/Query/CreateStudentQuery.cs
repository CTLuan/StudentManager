using MediatR;
using StudentManager.Application.Features.Student.DTOs;
using StudentManager.Shared.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Student.Query
{
    public class CreateStudentQuery : IRequest<ApiResponse<StudentDto>>
    {
        public Guid StudentID { get; set; }
    }
}
