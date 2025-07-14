using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentManager.Application.Features.User.Queries;

namespace StudentManager.Application.Validation
{
    public class GetUserByIDValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIDValidator() 
        {
            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage("UserID is required");
        }
    }
}
