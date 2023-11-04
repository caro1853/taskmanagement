using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Commands.CreateTask
{
	public class CreateTaskCommand: IRequest<int>
	{
        public string Name { get; set; }
        public DateTime? DeadLine { get; set; }

        //Owner
        public int UserId { get; set; }

        //Category
        public int? CategoryId { get; set; }
    }
}

