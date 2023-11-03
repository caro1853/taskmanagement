using System;
using FluentValidation;

namespace Tasking.Application.Features.Tasks.Commands.CreateTask
{
	public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
		public CreateTaskCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{Name} is required")
				.NotNull()
				.MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");

			RuleFor(p=> p.CategoryId)
				.NotEmpty().WithMessage("{CategoryId} is required")
				.GreaterThan(0).WithMessage("{CategoryId} should be greater than zero.");

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is required")
                .GreaterThan(0).WithMessage("{UserId} should be greater than zero.");
        }
	}
}

