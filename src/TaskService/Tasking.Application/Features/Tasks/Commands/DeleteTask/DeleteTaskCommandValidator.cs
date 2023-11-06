using System;
using FluentValidation;

namespace Tasking.Application.Features.Tasks.Commands.DeleteTask
{
	public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
		public DeleteTaskCommandValidator()
		{
            RuleFor(p => p.Taskid)
                .NotEmpty().WithMessage("{Id} is required.")
                .GreaterThan(0).WithMessage("{Id} is required.");

        }
    }
}

