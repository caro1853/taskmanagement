using System;
using MediatR;
using Tasking.Application.DTOs;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;

namespace Tasking.Application.Operations
{
    public class TaskOperations : ITaskOperations
    {
        private readonly IMediator _mediator;

        public TaskOperations(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksByOwner(string ownerName)
        {
            var query = new GetTaskListByOwnerQuery(ownerName);
            var tasks = await _mediator.Send(query);

            var taskDTO = new List<TaskDTO>();//TODO

            return taskDTO;
        }
    }
}

