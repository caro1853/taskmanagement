using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Commands.DeleteTask
{
	public class DeleteTaskCommand: IRequest
	{
		public readonly int Taskid;

        public DeleteTaskCommand(int taskid)
        {
            Taskid = taskid;
        }
    }
}

