using Api.Domain.Models.DTOs;
using FluentValidation;

namespace Api.Validation.UrlDTOs;

public class URLCreateRequestValidator : AbstractValidator<URLCreateRequest>
{
    public URLCreateRequestValidator()
    {
        RuleFor(x => x.OriginalURL)
            .NotEmpty().WithMessage("OriginalURL cannot be empty")
            .NotNull().WithMessage("OriginalURL cannot be null")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("OriginalURL must be a valid URL");

        RuleFor(x => x.CustomAlias)
            .MaximumLength(20).WithMessage("CustomAlias cannot exceed 20 characters");
    }
}