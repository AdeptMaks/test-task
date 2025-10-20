using Api.Domain.Models.DTOs;
using FluentValidation;

namespace Api.Validation.UserDTOs;

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login cannot be empty")
            .NotNull().WithMessage("Login cannot be null");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot empty")
            .NotNull().WithMessage("Password cannot be null");

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty().WithMessage("Password confirmation cannot be empty")
            .NotNull().WithMessage("Password confirmation cannot be null");
    }
}