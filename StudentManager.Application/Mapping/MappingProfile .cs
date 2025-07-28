using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManager.Application.Features.Student.DTOs;
using StudentManager.Application.Features.StudentRegistration.Command;
using StudentManager.Application.Features.User.DTOs;
using StudentManager.Application.Features.Users.Command;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserCommand>();
            CreateMap<CreateStudentRegistrationCommand, StudentRegistration>();
            CreateMap<StudentRegistration, StudentRegistrationDto>();
        }
    }
}
