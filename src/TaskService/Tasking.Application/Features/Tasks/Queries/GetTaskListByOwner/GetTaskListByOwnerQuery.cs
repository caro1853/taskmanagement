using System;
using MediatR;

namespace Tasking.Application.Features.Tasks.Queries.GetTaskListByOwner
{
	public class GetTaskListByOwnerQuery: IRequest<List<TaskVM>>
	{
		internal int UserId { get; set; }

        public GetTaskListByOwnerQuery(int userId)
        {
            UserId = userId;
        }
    }
}

