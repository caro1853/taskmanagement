using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasking.Application.Features.Tasks.Commands.CreateTask;
using Tasking.Application.Features.Tasks.Commands.UpdateTask;
using Tasking.Application.Features.Tasks.Queries.GetTaskById;
using Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner;
using Tasking.Application.Features.Tasks.Queries.GetTasksListByOwnerByCategory;

namespace Tasking.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("gettasksbyuser/{userid}")]
        [ProducesResponseType(typeof(IEnumerable<TaskVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskVM>>> GetTasksByUser(int userid)
        {
            var query = new GetTaskListByOwnerQuery(userid);
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpGet]
        [Route("gettasksbyuser/{userid}/category/{categoryid}")]
        [ProducesResponseType(typeof(IEnumerable<TaskVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskVM>>> GetTasksByUserCategory(int userid, int categoryid)
        {
            var query = new GetTasksListByOwnerByCategoryQuery(userid, categoryid);
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskByIdVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TaskByIdVM>> Get(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var task = await _mediator.Send(query);
            return Ok(task);
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

