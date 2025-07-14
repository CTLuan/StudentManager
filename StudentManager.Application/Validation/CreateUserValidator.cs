using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentManager.Application.Features.Users.Command;
using StudentManager.Application.Features.User.Queries;

namespace StudentManager.Application.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required");

            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("EmailAddress is required");

        }
    }
}
