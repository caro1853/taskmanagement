using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasking.Application.Features.Tasks.Commands.CreateTask;
using Tasking.Application.Features.Tasks.Commands.UpdateTask;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;
using Tasking.Application.Operations;

namespace Tasking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{userName}", Name = "GetTasksByUser")]
        [ProducesResponseType(typeof(IEnumerable<TaskVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskVM>>> GetTasksByUser(string userName)
        {
            var query = new GetTaskListByOwnerQuery(userName);
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpPost(Name = "CreateTask")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTask([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateTaskCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

