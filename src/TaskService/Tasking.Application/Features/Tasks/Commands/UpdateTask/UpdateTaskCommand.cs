using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Commands.UpdateTask
{
	public class UpdateTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? IsCompleted { get; set; }

        //Owner
        public int? UserId { get; set; }

        //Category
        public int? CategoryId { get; set; }
    }
}

