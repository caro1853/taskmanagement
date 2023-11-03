using System;
using MediatR;
using Tasking.Application.Contracts.Ports;
using Tasking.Application.DTOs;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;

namespace Tasking.Application.ImplementationsInputPorts
{
    public class GetTasksByOwnerInputPort : IGetTasksByOwnerInputPort
    {
        private readonly IMediator _mediator;
        private readonly IGetTasksByOwnerOutputPort _getTasksByOwnerOutputPort;

        public GetTasksByOwnerInputPort(IMediator mediator, IGetTasksByOwnerOutputPort getTasksByOwnerOutputPort)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _getTasksByOwnerOutputPort = getTasksByOwnerOutputPort ?? throw new ArgumentNullException(nameof(getTasksByOwnerOutputPort));
        }

        public async Task Handler(string userName)
        {
            var query = new GetTaskListByOwnerQuery(userName);
            var tasks = await _mediator.Send(query);

            var taskDTO = new List<TaskDTO>(); //TODO

            await _getTasksByOwnerOutputPort.Handler(taskDTO);
        }
    }
}

