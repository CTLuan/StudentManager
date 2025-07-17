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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")  // Đảm bảo mật khẩu có ít nhất 6 ký tự
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")  // Kiểm tra ít nhất một chữ hoa
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit")  // Kiểm tra ít nhất một chữ số
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character");  // Kiểm tra ít nhất một ký tự đặc biệt

        }
    }
}
