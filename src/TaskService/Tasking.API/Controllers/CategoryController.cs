using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasking.Application.Features.Categories.Queries.GetCategoriesList;
using Tasking.Application.Features.Tasks.Queries.GetTaskById;

namespace Tasking.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<GetCategoriesListVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetCategoriesListVM>>> Get()
        {
            var query = new GetCategoriesListQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }
    }
}

