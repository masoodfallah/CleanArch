using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{ProperttName} must not exceed {ComparisonValue} characters.");

        RuleFor(p => p.DefaultDays)
            .NotEmpty().WithMessage("{ProperttName} is required.")
            .GreaterThan(0).WithMessage("{ProperttName} must be at least 1.")
            .LessThan(100).WithMessage("{ProperttName} must be less than {ComparisonValue}.");

    }
}
