using Api.Domain.Models.DTOs;
using FluentValidation;

namespace Api.Validation.UserDTOs;

public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login cannot be empty")
            .NotNull().WithMessage("Login cannot be null");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .NotNull().WithMessage("Password cannot be null");
    }
}